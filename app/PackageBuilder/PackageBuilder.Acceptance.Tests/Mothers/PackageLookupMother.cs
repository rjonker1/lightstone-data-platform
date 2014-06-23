using PackageBuilder.Acceptance.Tests.Builders.Entites;
using PackageBuilder.Acceptance.Tests.Builders.Repositories;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api;

namespace PackageBuilder.Acceptance.Tests.Mothers
{
    public class PackageLookupMother
    {
        /// <summary>
        /// 	Customer: Create a customer called “Wesbank” and allocate the customer to a contract.
	    ///     Datasets: Create 5 datasets allocating the relevant fields to each dataset:
        ///         • Vehicle verification
        ///         • Repair history
        ///         • Values
        ///         • Driver’s license scan
        ///         • EzScore
	    ///     Packages: Create 4 packages
        ///         • Full suite with all 5 datasets allocated to the package
        ///         • Vehicle Verification + Repair History + Values package with the appropriate datasets allocated to the package
        ///         • Driver’s license scan package with the Driver’s license scan dataset allocated to the package
        ///         • EzScore package with the EzScore dataset allocated to the package
	    ///     Costing: Set up costing for packages
        ///         • Each package will have two costing records. The first record will describe the price until 28 February 2014 and the second will have no expiry date
        ///         • Wesbank will be billed automatically based on the costing records
        ///             • Thus if the API is invoked and the Vehicle Verification + Repair History + Values package is executed on 27 February 2014 Wesbank will be billed R32.25.
        ///             • The same API call will be billed at R50.40 on 3 March 2014.
	    ///     Access control: Setup package mappings to actions / users / groups / roles
        ///         • Map the EzScore package to the “Get EzScore” action
        ///         • Map the Driver’s license scan package to the “Scan license disk” action
        ///         • Map the Vehicle Verification + Repair History + Values package to the “Verify” action
        ///         • Map the Full suite package to the “Complete info” action

        ///     When a user belonging to the Wesbank customer now invokes the API (via the mobile app or website) with the action “Verify” 
        ///     the package builder will tell the API to execute the Vehicle Verification + Repair History + Values package. The API will 
        ///     then look to see which datasets belong to the Vehicle Verification + Repair History + Values package. Once the datasets are known, 
        ///     each dataset will tell the API which external sources to query (based on the field to dataset relationships). 
        ///     The API will then query the relevant external sources. Once the data is available from the external sources, 
        ///     the fields allocated to each dataset will be retrieved from the external source responses. The retrieved fields will then be returned to the caller of the API.
        /// </summary>
        /// <returns></returns>
        public static IPackageLookupRepository GetWesbankScenario()
        {
            var user = UserBuilder.Get("TestUser");
            var contract = ContractBuilder.Get("Wesbank contract");
            var customer = CustomerBuilder.Get("Wesbank", user, contract);

            var contractPackageFull = ContractPackageBuilder.Get(PackageMother.FullVerificationPackage, contract);
            var contractPackageVerfiy = ContractPackageBuilder.Get(PackageMother.PartialVerificationPackage, contract);
            var contractPackageLicenseScan = ContractPackageBuilder.Get(PackageMother.LicenseScanPackage, contract);
            var contractPackageEzScore = ContractPackageBuilder.Get(PackageMother.EzScorePackage, contract);

            return new PackageLookup(
                CustomerRepositoryBuilder.Get(customer),
                ActionRepositoryMother.Get(), 
                new TestUserPackageRepository(), 
                new TestRolePackageRepository(), 
                new TestGroupPackageRepository(), 
                ContractRepositoryBuilder.Get(contract),
                ContractPackageRepositoryBuilder.Get(contractPackageFull, contractPackageVerfiy, contractPackageLicenseScan, contractPackageEzScore)
                );
        }

        /// <summary>
        ///     If we were to look a more complex scenario (and keeping in mind the configuration already done for Wesbank) it will become clear how the existing configuration can be reused and customised to cater for more complex scenarios

        ///     The scenario is as follows:
        ///     A new customer (Acme) wants to use Lightstone to streamline their sales process and provide vehicle information to minimise data entry.

        ///     Acme wants access to the driver’s license scan, EzScore, vehicle verification, repair history and sales history functionality. 
        ///         • A group (G1) of users can scan a license disk, but can’t verify the information. 
        ///         • Another group (G2) of users can request an EzScore report.
        ///         • And finally a group (G3) of users can request vehicle verification, repair history and sales history.
        ///         • All users in a certain role (R1) should be able to scan a driver’s license and get verification and values for the scan.
        ///     Just to complicate things a bit more; 
        ///         • some users in group G3 also belong to role R1 
        ///         • users in G2 need to be able to scan a driver’s license and get verification and values for the scan.

        ///     Acme has the following users with group and role relationships
        ///         • User U1 belongs to group G1
        ///         • User U2 belongs to group G2
        ///         • User U3 belongs to group G3
        ///         • User U4 belongs to role R1
        ///         • User U5 belongs to group G3 and role R1

        ///     Acme signed up for three years with a price increase of 5% per year, starting on 1 March 2014.

        ///     To implement the customer’s requirements the following steps are implemented
        ///         Customer: Create a customer called “Acme” and allocate the customer to a contract (C1). The contract will be valid until 28 February 2016.
        ///         Datasets: As datasets have already been set up for Wesbank
        ///             • Vehicle verification (reuse from Wesbank) – D1
        ///             • Repair history (reuse from Wesbank) – D2
        ///             • Values (reuse from Wesbank) – D3
        ///             • Driver’s license scan (reuse from Wesbank) – D4
        ///             • EzScore (reuse from Wesbank) – D5
        ///         Packages: As packages for Wesbank have already been set 
        ///             • Vehicle Verification + Repair History + Values package (reuse from Wesbank) – P1
        ///             • Driver’s license scan package (reuse from Wesbank) – P2
        ///             • EzScore package (reuse from Wesbank) – P3
        ///             • Driver’s license scan with verification and vehicle values (new package). The information will be provided by Vehicle verification (D1), Values (D3) and Driver’s license scan (D4) – P4
        ///         Costing: Set up costing for packages
        ///             Each package will have three costing records. 
        ///                 • The first record will describe the price until 1 March 2015 
        ///                 • The second record will describe the price until 1 March 2016
        ///                 • The third record will describe the price until 1 March 2017
        ///             Acme will be billed automatically based on the costing records
        ///         Actions / functionality:
        ///             • Driver’s license scan – A1
        ///             • EzScore report – A2
        ///             • Full verification – A3
        ///             • Partial verification – A4
        ///         Access control: Setup package mappings to actions / users / groups / roles
        ///             • Users In G1 can only invoke package P2
        ///             • If users in G2 perform action A2, package P3 is invoked
        ///             • If users in G2 perform action A4, package P4 is invoked
        ///             • If users in G3 with role R1 perform action A4, package P4 is invoked
        ///             • Users in G3 with no role can only invoke package P1
        ///             • If user in role R1 and group G3 performs action A3, package P1 is invoked.
        /// </summary>
        /// <returns></returns>
        public static IPackageLookupRepository GetAcmeScenario()
        {
            var role1 = RoleBuilder.Get("role1");
            var group1 = GroupBuilder.Get("group1");
            var group2 = GroupBuilder.Get("group2");
            var group3 = GroupBuilder.Get("group3");

            var user1 = UserBuilder.Get("user1");
            var user2 = UserBuilder.Get("user2");
            var user3 = UserBuilder.Get("user3");
            var user4 = UserBuilder.Get("user4");
            var user5 = UserBuilder.Get("user5");

            // Assign user1 to group1
            user1.Add(group1);
            // Assign user2 to group2
            user2.Add(group2);
            // Assign user3 to group3
            user3.Add(group3);
            // Assign user4 to role1
            user4.Add(role1);
            // Assign user5 to role1 & group 3
            user5.Add(role1);
            user5.Add(group3);

            var contract = ContractBuilder.Get("Acme contract");
            var customer = CustomerBuilder.Get("Acme", user1, contract);
            customer.Add(user2);
            customer.Add(user3);
            customer.Add(user4);
            customer.Add(user5);

            var groupPackage1 = GroupPackageBuilder.Get(PackageMother.LicenseScanPackage, customer, group1);
            var groupPackage2 = GroupPackageBuilder.Get(PackageMother.EzScorePackage, customer, group2);
            var groupPackage3 = GroupPackageBuilder.Get(PackageMother.PartialVerificationPackage, customer, group2);
            var groupPackage4 = GroupPackageBuilder.Get(PackageMother.FullVerificationPackage, customer, group3);

            var rolePackage1 = RolePackageBuilder.Get(PackageMother.PartialVerificationPackage, customer, role1);

            return new PackageLookup(
                CustomerRepositoryBuilder.Get(customer),
                ActionRepositoryMother.Get(),
                new TestUserPackageRepository(),
                RolePackageRepositoryBuilder.Get(rolePackage1),
                GroupPackageRepositoryBuilder.Get(groupPackage1, groupPackage2, groupPackage3, groupPackage4),
                ContractRepositoryBuilder.Get(contract),
                new TestContractPackageRepository()
                );
        }
    }
}