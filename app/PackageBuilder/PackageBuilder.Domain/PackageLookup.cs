using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.Domain
{
    public class PackageLookup : IPackageLookupRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IActionRepository _actionRepository;
        private readonly IUserPackageRepository _userPackageRepository;
        private readonly IRolePackageRepository _rolePackageRepository;
        private readonly IGroupPackageRepository _groupPackageRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IContractPackageRepository _contractPackageRepository;

        public PackageLookup(ICustomerRepository customerRepository, 
                             IActionRepository actionRepository, 
                             IUserPackageRepository userPackageRepository,
                             IRolePackageRepository rolePackageRepository,
                             IGroupPackageRepository groupPackageRepository,
                             IContractRepository contractRepository,
                             IContractPackageRepository contractPackageRepository)
        {
            _customerRepository = customerRepository;
            _actionRepository = actionRepository;
            _userPackageRepository = userPackageRepository;
            _rolePackageRepository = rolePackageRepository;
            _groupPackageRepository = groupPackageRepository;
            _contractRepository = contractRepository;
            _contractPackageRepository = contractPackageRepository;
        }

        public IPackage Get(string username, string requestedAction)
        {
            var user = _customerRepository.GetUser(username);
            var action = _actionRepository.FindByName(requestedAction);
            var package = _userPackageRepository.GetPackage(user, action);
            if (package != null) return package;

            package = user.HasSingleGroupAndRole || user.HasSingleRole ? _rolePackageRepository.GetPackage(user, action) : _groupPackageRepository.GetPackage(user, action);
            if (package != null) return package;

            package = user.HasMultipleGroupsAndRoles || user.HasSingleRole ? _rolePackageRepository.GetRolePackage(user, action) : _groupPackageRepository.GetGroupPackage(user, action);
            if (package != null) return package;

            // ToDo: Contract lookup
            var contract = _contractRepository.First();
            package = _contractPackageRepository.GetPackage(contract, action);

            return package;
        }

        public IEnumerable<IAction> GetActions(string username)
        {
            var user = _customerRepository.GetUser(username);
            var actions = _userPackageRepository.GetActions(user);
            if (actions != null && actions.Any()) return actions;

            actions = user.HasSingleGroupAndRole || user.HasSingleRole ? _rolePackageRepository.GetActions(user) : _groupPackageRepository.GetActions(user);
            if (actions != null && actions.Any()) return actions;

            actions = user.HasMultipleGroupsAndRoles || user.HasSingleRole ? _rolePackageRepository.GetActions(user) : _groupPackageRepository.GetActions(user);
            if (actions != null && actions.Any()) return actions;

            // ToDo: Contract lookup
            var contract = _contractRepository.First();
            actions = _contractPackageRepository.GetActions(contract);

            return actions;
        }
    }
}