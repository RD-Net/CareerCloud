using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    interface ICompany
    {
        [OperationContract]
        void AddCompanyDescription(CompanyDescriptionPoco[] pocos);

        [OperationContract]
        CompanyDescriptionPoco GetSingleCompanyDescription(Guid id);

        [OperationContract]
        List<CompanyDescriptionPoco> GetAllCompanyDescription();

        [OperationContract]
        void UpdateCompanyDescription(CompanyDescriptionPoco[] pocos);

        [OperationContract]
        void RemoveCompanyDescription(CompanyDescriptionPoco[] pocos);

        [OperationContract]
        void AddCompanyJobDescription(CompanyJobDescriptionPoco[] pocos);

        [OperationContract]
        CompanyJobDescriptionPoco GetSingleCompanyJobDescription(Guid id);

        [OperationContract]
        List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription();

        [OperationContract]
        void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] pocos);

        [OperationContract]
        void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] pocos);

        [OperationContract]
        void AddCompanyJobEducation(CompanyJobEducationPoco[] pocos);

        [OperationContract]
        CompanyJobEducationPoco GetSingleCompanyJobEducation(Guid id);

        [OperationContract]
        List<CompanyJobEducationPoco> GetAllCompanyJobEducation();

        [OperationContract]
        void UpdateCompanyJobEducation(CompanyJobEducationPoco[] pocos);

        [OperationContract]
        void RemoveCompanyJobEducation(CompanyJobEducationPoco[] pocos);

        [OperationContract]
        void AddCompanyJob(CompanyJobPoco[] pocos);

        [OperationContract]
        CompanyJobPoco GetSingleCompanyJob(Guid id);

        [OperationContract]
        List<CompanyJobPoco> GetAllCompanyJob();

        [OperationContract]
        void UpdateCompanyJob(CompanyJobPoco[] pocos);

        [OperationContract]
        void RemoveCompanyJob(CompanyJobPoco[] pocos);

        [OperationContract]
        void AddCompanyJobSkill(CompanyJobSkillPoco[] pocos);

        [OperationContract]
        CompanyJobSkillPoco GetSingleCompanyJobSkill(Guid id);

        [OperationContract]
        List<CompanyJobSkillPoco> GetAllCompanyJobSkill();

        [OperationContract]
        void UpdateCompanyJobSkill(CompanyJobSkillPoco[] pocos);

        [OperationContract]
        void RemoveCompanyJobSkill(CompanyJobSkillPoco[] pocos);

        [OperationContract]
        void AddCompanyLocation(CompanyLocationPoco[] pocos);

        [OperationContract]
        CompanyLocationPoco GetSingleCompanyLocation(Guid id);

        [OperationContract]
        List<CompanyLocationPoco> GetAllCompanyLocation();

        [OperationContract]
        void UpdateCompanyLocation(CompanyLocationPoco[] pocos);

        [OperationContract]
        void RemoveCompanyLocation(CompanyLocationPoco[] pocos);

        [OperationContract]
        void AddCompanyProfile(CompanyProfilePoco[] pocos);

        [OperationContract]
        CompanyProfilePoco GetSingleCompanyProfile(Guid id);

        [OperationContract]
        List<CompanyProfilePoco> GetAllCompanyProfile();

        [OperationContract]
        void UpdateCompanyProfile(CompanyProfilePoco[] pocos);

        [OperationContract]
        void RemoveCompanyProfile(CompanyProfilePoco[] pocos);










    }
}
