using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    interface ISecurity
    {
        [OperationContract]
        void AddSecurityLogin(SecurityLoginPoco[] pocos);

        [OperationContract]
        SecurityLoginPoco GetSingleSecurityLogin(Guid id);

        [OperationContract]
        List<SecurityLoginPoco> GetAllSecurityLogin();

        [OperationContract]
        void UpdateSecurityLogin(SecurityLoginPoco[] pocos);

        [OperationContract]
        void RemoveSecurityLogin(SecurityLoginPoco[] pocos);

        [OperationContract]
        void AddSecurityLoginsLog(SecurityLoginsLogPoco[] pocos);

        [OperationContract]
        SecurityLoginsLogPoco GetSingleSecurityLoginsLog(Guid id);

        [OperationContract]
        List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog();

        [OperationContract]
        void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] pocos);

        [OperationContract]
        void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] pocos);
        [OperationContract]
        void AddSecurityLoginsRole(SecurityLoginsRolePoco[] pocos);

        [OperationContract]
        SecurityLoginsRolePoco GetSinglesecurityLoginsRole(Guid id);

        [OperationContract]
        List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole();

        [OperationContract]
        void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] pocos);

        [OperationContract]
        void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] pocos);

        [OperationContract]
        void AddSecurityRole(SecurityRolePoco[] pocos);

        [OperationContract]
        SecurityRolePoco GetSinglesecurityRole(Guid id);

        [OperationContract]
        List<SecurityRolePoco> GetAllSecurityRole();

        [OperationContract]
        void UpdateSecurityRole(SecurityRolePoco[] pocos);

        [OperationContract]
        void RemoveSecurityRole(SecurityRolePoco[] pocos);

    }
}
