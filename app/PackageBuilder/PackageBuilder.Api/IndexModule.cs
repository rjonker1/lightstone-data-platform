using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Api
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/package/{action}"] = parameters =>
            {
                var package = new PackageLookup().Get("admin", parameters.action);

                return Response.AsJson(new {package});
            };

            Get["/"] = parameters =>
            {
                var actions = new PackageLookup().GetActions("admin");
                
                return Response.AsJson(new { actions });
            };
        }
    }

    public class PackageLookup
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        private readonly IActionRepository _actionRepository = new ActionRepository();
        private readonly IUserPackageRepository _userPackageRepository = new UserPackageRepository();
        private readonly IRolePackageRepository _rolePackageRepository = new RolePackageRepository();
        private readonly IGroupPackageRepository _groupPackageRepository = new GroupPackageRepository();
        private readonly IContractRepository _contractRepository = new ContractRepository();
        private readonly IContractPackageRepository _contractPackageRepository = new ContractPackageRepository();
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