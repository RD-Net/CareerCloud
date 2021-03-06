﻿using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Wcf
{
    [ServiceContract]
    interface IApplicant
    {
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] pocos);

        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(String id);

        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();

        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] pocos);

        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] pocos);

        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(String id);

        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();

        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(String id);

        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();

        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(String id);

        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();

        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(String id);

        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();

        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(String id);

        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();

        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

    }
}
