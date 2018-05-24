﻿using System;
using System.Collections.Generic;
using FinServUnitOfWork.Interface;
using FinServDataModel;
using System.Linq;
using FinServBussinessEntities;

namespace FinServUnitOfWork.Repository
{
    public class UOWMasters : IMasters
    {
        #region Get
        public List<ApplicantTypeMaster> GetApplicantTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ApplcntMstr in db.tblMasterApplicantTypes
                            select new ApplicantTypeMaster()
                            {
                                ApplicantType = ApplcntMstr.ApplicantType,
                                ApplicantTypeID = ApplcntMstr.ApplicantTypeID,
                                IsActive = ApplcntMstr.IsActive,

                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<AssetsTypeMaster> GetAssetsTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from AssetstMstr in db.tblMasterAssetTypes
                            select new AssetsTypeMaster()
                            {
                                AssetType = AssetstMstr.AssetType,
                                AssetTypeID = AssetstMstr.AssetTypeID,
                                AutoID = AssetstMstr.AutoID,
                                IsActive = AssetstMstr.IsActive,
                            }).ToList();
                    
                    
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<AdvisorTypeDetails> GetAdvisorGroups()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from advsrdtls in db.tblAdvisorDetails
                            select new AdvisorTypeDetails()
                            {
                                AdvisorID = advsrdtls.AdvisorID,
                                AutoID=advsrdtls.AutoID,
                                AdvisorCode = advsrdtls.AdvisorCode,
                                AdvisorGroup = advsrdtls.AdvisorGroup,
                            }).ToList();


                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<EmploymentTypeMaster> GetEmploymentTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from EmpMstr in db.tblMasterTypeOfEmployments
                            select new EmploymentTypeMaster()
                            {
                                EmployementType = EmpMstr.EmployementType,
                                ID = EmpMstr.ID,
                                IsActive = EmpMstr.IsActive,
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<ExpenseTypeMaster> GetExpenseTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ExpnsMstr in db.tblMasterExpenseTypes
                            select new ExpenseTypeMaster()
                            {
                                ExpenseType = ExpnsMstr.ExpenseType,
                                AutoID = ExpnsMstr.AutoID,
                                ExpenseTypeID = ExpnsMstr.ExpenseTypeID,
                                Frequency = ExpnsMstr.Frequency,
                                IsActive = ExpnsMstr.IsActive
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<LiabilityTypeMaster> GetLiabilityTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from LbltyMstr in db.tblMasterLiabilityTypes
                            select new LiabilityTypeMaster()
                            {
                                LiabilityType = LbltyMstr.LiabilityType,
                                AutoID = LbltyMstr.AutoID,
                                LiabilityTypeID = LbltyMstr.LiabilityTypeID,
                                IsActive = LbltyMstr.IsActive
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<LoanTypeMaster> GetLoanTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from LoanMstr in db.tblMasterTypeOfLoans
                            select new LoanTypeMaster()
                            {
                                ID = LoanMstr.ID,
                                LoanType = LoanMstr.LoanType,
                                IsActive = LoanMstr.IsActive
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<LoanRateTypeMaster> GetLoanrateTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from LoanMstr in db.tblMasterLoanRateTypes
                            select new LoanRateTypeMaster()
                            {
                                ID = LoanMstr.ID,
                                LoanRateType = LoanMstr.LoanRateType,
                                IsActive = LoanMstr.IsActive
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<PropertyTypeMaster> GetPropertyTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjMstr in db.tblMasterPropertyTypes
                            select new PropertyTypeMaster()
                            {
                                ID = ObjMstr.ID,
                                PropertyType = ObjMstr.PropertyType,
                                IsActive = ObjMstr.IsActive,

                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<PurposeOfLoanMaster> GetPurposeofloanTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjMstr in db.tblMasterPurposeOfLoans
                            select new PurposeOfLoanMaster()
                            {
                                ID = ObjMstr.ID,
                                PurposeOfLoan = ObjMstr.PurposeOfLoan,
                                IsActive = ObjMstr.IsActive,

                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<ProfessionTypeMaster> GetProfessionTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ProMstr in db.tblMasterTypeOfProfessions
                            select new ProfessionTypeMaster()
                            {
                                Profession = ProMstr.Profession,
                                ID = ProMstr.ID,
                                IsActive = ProMstr.IsActive
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<QualificationTypeMaster> GetQualificationTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from QualMstr in db.tblMasterTypeOfQualifications
                            select new QualificationTypeMaster()
                            {
                                Qualifications = QualMstr.Qualifications,
                                ID = QualMstr.ID,
                                IsActive = QualMstr.IsActive
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<RelationshipTypeMaster> GetRelationshipTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from RelMstr in db.tblMasterTypeOfRelationships
                            select new RelationshipTypeMaster()
                            {
                                RelationshipWithApplicant = RelMstr.RelationshipWithApplicant,
                                ID = RelMstr.ID,
                                IsActive = RelMstr.IsActive
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<SalutationTypeMaster> GetSalutationTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjMstr in db.tblMasterSalutations
                            select new SalutationTypeMaster()
                            {
                                ID = ObjMstr.ID,
                                Salutation = ObjMstr.Salutation,
                                IsActive = ObjMstr.IsActive,

                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Added by Neha

        public List<StatusTypeMaster> GetStatusTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjMstr in db.tblMasterTypeOfStatus
                            select new StatusTypeMaster()
                            {
                                ID = ObjMstr.ID,
                                Status = ObjMstr.Status,
                                IsActive = ObjMstr.IsActive,

                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<Applicants> GetApplicants() {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjAplcnts in db.tblApplicants
                            select new Applicants()
                            {
                                ApplicantID = ObjAplcnts.ApplicantID,
                                AutoID = ObjAplcnts.AutoID,
                                Title = ObjAplcnts.Title,
                                FirstName = ObjAplcnts.FirstName,
                                MiddleName=ObjAplcnts.MiddleName,
                                LastName = ObjAplcnts.LastName
                            })
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Applicants> GetApplicantNames(string loanappno)
        {
            try
            {
                Guid appGuid = Guid.Parse(loanappno);
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjAplcnts in db.tblApplicants
                            .Where(p => p.LoanApplicationNo == appGuid)
                            select new Applicants()
                            {
                                AutoID = ObjAplcnts.AutoID,
                                ApplicantID = ObjAplcnts.ApplicantID,
                                FirstName = ObjAplcnts.FirstName
                            })
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LoanApplicationForms> GetApplicationFormNo()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjAplctnFormNo in db.tblLoanApplicationForms
                            .Where(p => p.IsApplicationApproved == true)
                            select new LoanApplicationForms()
                            {
                                AutoID = ObjAplctnFormNo.AutoID,
                                ApplicationFormNumber = ObjAplctnFormNo.ApplicationFormNumber
                            })
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UserDetails> GetUpdatedPassword(Guid UserGuid)
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from UpdtPasswrdObj in db.tblUsers
                            .Where(p => p.UserGuid == UserGuid)
                            select new UserDetails()
                            {
                                UserGuid = UpdtPasswrdObj.UserGuid,
                                Password = UpdtPasswrdObj.Password
                            })
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AddressTypeMaster> GetAddressTypes()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from ObjAddressTyp in db.tblMasterAddressTypes
                            select new AddressTypeMaster()
                            {
                                ID = ObjAddressTyp.ID,
                                Type = ObjAddressTyp.Type
                            })
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Applicants GetUserDetails(Guid ApplicantID)
        {
            try
            {
                Applicants objApplicants = new Applicants();
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetApplicantDetails = db.tblApplicants.Where(p =>  p.ApplicantID == ApplicantID).FirstOrDefault();
                    if (GetApplicantDetails != null)
                    {
                        objApplicants.ApplicantID = GetApplicantDetails.ApplicantID;
                        objApplicants.ApplicantTypeID = GetApplicantDetails.ApplicantTypeID;
                        objApplicants.AutoID = GetApplicantDetails.AutoID;
                        objApplicants.EmailID = GetApplicantDetails.EmailID;
                        objApplicants.FirstName = GetApplicantDetails.FirstName;
                        objApplicants.LastName = GetApplicantDetails.LastName;
                        objApplicants.MobileNo = GetApplicantDetails.MobileNo;
                       
                    }
                    return objApplicants;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region Switch Status
        public bool SwitchApplicantEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterApplicantTypes.Where(p => p.ApplicantTypeID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchAssetsEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterAssetTypes.Where(p => p.AutoID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchEmploymentEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetEmploymentEntity = db.tblMasterTypeOfEmployments.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetEmploymentEntity != null)
                    {
                        GetEmploymentEntity.IsActive = !GetEmploymentEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchExpenseEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterExpenseTypes.Where(p => p.AutoID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchLiabilityEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterLiabilityTypes.Where(p => p.AutoID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchLoanEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterTypeOfLoans.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchLoanrateEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterLoanRateTypes.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchProfessionEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetProfessionEntity = db.tblMasterTypeOfProfessions.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetProfessionEntity != null)
                    {
                        GetProfessionEntity.IsActive = !GetProfessionEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchPropertyEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterPropertyTypes.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchPurposeofloanEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterPurposeOfLoans.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchQualificationEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetQualificationEntity = db.tblMasterTypeOfQualifications.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetQualificationEntity != null)
                    {
                        GetQualificationEntity.IsActive = !GetQualificationEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchRelationshipEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetRelationshipEntity = db.tblMasterTypeOfRelationships.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetRelationshipEntity != null)
                    {
                        GetRelationshipEntity.IsActive = !GetRelationshipEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SwitchSalutationEntityStatus(int ID)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterSalutations.Where(p => p.ID == ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.IsActive = !GetObjEntity.IsActive;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SwitchManageUserEntityStatus(Guid UserGuid)
        {
         
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetEmploymentEntity = db.tblUsers.Where(p => p.UserGuid == UserGuid).FirstOrDefault();
                    if (GetEmploymentEntity != null)
                    {
                        GetEmploymentEntity.IsActive = !GetEmploymentEntity.IsActive;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region Update entity
        public bool UpdateApplicantEntity(ApplicantTypeMaster ApplicantTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterApplicantTypes.Where(p => p.ApplicantTypeID == ApplicantTypeMaster.ApplicantTypeID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.ApplicantType = ApplicantTypeMaster.ApplicantType;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateAssetsEntity(AssetsTypeMaster AssetsTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterAssetTypes.Where(p => p.AutoID == AssetsTypeMaster.AutoID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.AssetType = AssetsTypeMaster.AssetType;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateEmploymentEntity(EmploymentTypeMaster EmploymentTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetEmploymentEntity = db.tblMasterTypeOfEmployments.Where(p => p.ID == EmploymentTypeMaster.ID).FirstOrDefault();
                    if (GetEmploymentEntity != null)
                    {
                        GetEmploymentEntity.EmployementType = EmploymentTypeMaster.EmployementType;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateExpenseEntity(ExpenseTypeMaster ExpenseTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterExpenseTypes.Where(p => p.AutoID == ExpenseTypeMaster.AutoID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.ExpenseType = ExpenseTypeMaster.ExpenseType;
                        GetObjEntity.Frequency = ExpenseTypeMaster.Frequency;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateLiabilityEntity(LiabilityTypeMaster LiabilityTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterLiabilityTypes.Where(p => p.AutoID == LiabilityTypeMaster.AutoID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.LiabilityType = LiabilityTypeMaster.LiabilityType;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateLoanEntity(LoanTypeMaster LoanTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterTypeOfLoans.Where(p => p.ID == LoanTypeMaster.ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.LoanType = LoanTypeMaster.LoanType;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateLoanrateEntity(LoanRateTypeMaster LoanRateTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterLoanRateTypes.Where(p => p.ID == LoanRateTypeMaster.ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.LoanRateType = LoanRateTypeMaster.LoanRateType;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateProffessionEntity(ProfessionTypeMaster ProfessionTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetProfessionEntity = db.tblMasterTypeOfProfessions.Where(p => p.ID == ProfessionTypeMaster.ID).FirstOrDefault();
                    if (GetProfessionEntity != null)
                    {
                        GetProfessionEntity.Profession = ProfessionTypeMaster.Profession;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdatePropertyEntity(PropertyTypeMaster PropertyTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterPropertyTypes.Where(p => p.ID == PropertyTypeMaster.ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.PropertyType = PropertyTypeMaster.PropertyType;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdatePurposeofloanEntity(PurposeOfLoanMaster PurposeOfLoanMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterPurposeOfLoans.Where(p => p.ID == PurposeOfLoanMaster.ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.PurposeOfLoan = PurposeOfLoanMaster.PurposeOfLoan;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateQualificationEntity(QualificationTypeMaster QualificationTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetQualificationEntity = db.tblMasterTypeOfQualifications.Where(p => p.ID == QualificationTypeMaster.ID).FirstOrDefault();
                    if (GetQualificationEntity != null)
                    {
                        GetQualificationEntity.Qualifications = QualificationTypeMaster.Qualifications;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool UpdateRelationshipEntity(RelationshipTypeMaster RelationshipTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetRelationshipEntity = db.tblMasterTypeOfRelationships.Where(p => p.ID == RelationshipTypeMaster.ID).FirstOrDefault();
                    if (GetRelationshipEntity != null)
                    {
                        GetRelationshipEntity.RelationshipWithApplicant = RelationshipTypeMaster.RelationshipWithApplicant;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateSalutationEntity(SalutationTypeMaster SalutationTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetObjEntity = db.tblMasterSalutations.Where(p => p.ID == SalutationTypeMaster.ID).FirstOrDefault();
                    if (GetObjEntity != null)
                    {
                        GetObjEntity.Salutation = SalutationTypeMaster.Salutation;
                        operationResult = db.SaveChanges();
                    }
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region Add entity
        public bool AddApplicantEntity(ApplicantTypeMaster ApplicantTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterApplicantType Obj = new tblMasterApplicantType();
                    Obj.ApplicantType = ApplicantTypeMaster.ApplicantType;
                    Obj.IsActive = true;
                    db.tblMasterApplicantTypes.Add(Obj);

                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddAssetsEntity(AssetsTypeMaster AssetsTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterAssetType Obj = new tblMasterAssetType();
                    Obj.AssetTypeID = Guid.NewGuid();
                    Obj.AssetType = AssetsTypeMaster.AssetType;
                    Obj.IsActive = true;
                    db.tblMasterAssetTypes.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddEmploymentEntity(EmploymentTypeMaster EmploymentTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterTypeOfEmployment Obj = new tblMasterTypeOfEmployment();
                    Obj.EmployementType = EmploymentTypeMaster.EmployementType;
                    Obj.IsActive = true;
                    db.tblMasterTypeOfEmployments.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddExpenseEntity(ExpenseTypeMaster ExpenseTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                   tblMasterExpenseType Obj = new tblMasterExpenseType();
                    Obj.ExpenseType = ExpenseTypeMaster.ExpenseType;
                    Obj.ExpenseTypeID = Guid.NewGuid();
                    Obj.IsActive = true;
                    db.tblMasterExpenseTypes.Add(Obj);

                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddLiabilityEntity(LiabilityTypeMaster LiabilityTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterLiabilityType Obj = new tblMasterLiabilityType();
                    Obj.LiabilityTypeID = Guid.NewGuid();
                    Obj.LiabilityType = LiabilityTypeMaster.LiabilityType;
                    Obj.IsActive = true;
                    db.tblMasterLiabilityTypes.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddLoanEntity(LoanTypeMaster LoanTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterTypeOfLoan Obj = new tblMasterTypeOfLoan();
                    Obj.LoanType= LoanTypeMaster.LoanType;
                    Obj.IsActive = true;
                    db.tblMasterTypeOfLoans.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddLoanrateEntity(LoanRateTypeMaster LoanRateTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterLoanRateType Obj = new tblMasterLoanRateType();
                    Obj.LoanRateType = LoanRateTypeMaster.LoanRateType;
                    Obj.IsActive = true;
                    db.tblMasterLoanRateTypes.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddProffessionEntity(ProfessionTypeMaster ProfessionTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterTypeOfProfession Obj = new tblMasterTypeOfProfession();
                    Obj.Profession = ProfessionTypeMaster.Profession;
                    Obj.IsActive = true;
                    db.tblMasterTypeOfProfessions.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddPropertyEntity(PropertyTypeMaster PropertyTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterPropertyType Obj = new tblMasterPropertyType();
                    Obj.PropertyType = PropertyTypeMaster.PropertyType;
                    Obj.IsActive = true;
                    db.tblMasterPropertyTypes.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddPurposeofloanEntity(PurposeOfLoanMaster PurposeOfLoanMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterPurposeOfLoan Obj = new tblMasterPurposeOfLoan();
                    Obj.PurposeOfLoan = PurposeOfLoanMaster.PurposeOfLoan;
                    Obj.IsActive = true;
                    db.tblMasterPurposeOfLoans.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddQualificationEntity(QualificationTypeMaster QualificationTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterTypeOfQualification Obj = new tblMasterTypeOfQualification();
                    Obj.Qualifications = QualificationTypeMaster.Qualifications;
                    Obj.IsActive = true;
                    db.tblMasterTypeOfQualifications.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool AddRelationshipEntity(RelationshipTypeMaster RelationshipTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterTypeOfRelationship Obj = new tblMasterTypeOfRelationship();
                    Obj.RelationshipWithApplicant = RelationshipTypeMaster.RelationshipWithApplicant;
                    Obj.IsActive = true;
                    db.tblMasterTypeOfRelationships.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddSalutationEntity(SalutationTypeMaster SalutationTypeMaster)
        {
            int operationResult = 0;
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    tblMasterSalutation Obj = new tblMasterSalutation();
                    Obj.Salutation = SalutationTypeMaster.Salutation;
                    Obj.IsActive = true;
                    db.tblMasterSalutations.Add(Obj);
                    operationResult = db.SaveChanges();
                }
                if (operationResult > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        public List<UserDetails> GetAllUser()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from MasterUser in db.tblUsers
                            select new UserDetails()
                            {
                                UserGuid = MasterUser.UserGuid,
                                FirstName = MasterUser.FirstName,
                                LastName = MasterUser.LastName,
                                DisplayName = MasterUser.DisplayName,
                                Role = MasterUser.Role,
                                EmailID = MasterUser.Email,
                                Mobile = MasterUser.Mobile,
                                Password = MasterUser.Password,
                                LoginID = MasterUser.LoginID,
                                IsActive = MasterUser.IsActive

                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Role> GetRoleType()
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    return (from UserRoleType in db.tblRoles
                            select new Role()
                            {
                                RoleId = UserRoleType.RoleId,
                                Name = UserRoleType.Name,
                                Description = UserRoleType.Description,

                            }).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AddUser(UserDetails _objUserDetails)
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {

                        tblUser _objDetails = new tblUser();
                        _objDetails.UserGuid = Guid.NewGuid();
                        _objDetails.LoginID = _objUserDetails.LoginID;
                        _objDetails.FirstName = _objUserDetails.FirstName;
                        _objDetails.LastName = _objUserDetails.LastName;
                        _objDetails.DisplayName = _objUserDetails.DisplayName;
                        _objDetails.Email = _objUserDetails.EmailID;
                        _objDetails.Password = _objUserDetails.Password;
                       _objDetails.Mobile = _objUserDetails.Mobile;
                       _objDetails.Role = _objUserDetails.Role;
                       _objDetails.CreatedBy = _objUserDetails.CreatedBy;
                       _objDetails.CreatedOn = _objUserDetails.CreatedOn;
                       _objDetails.IsActive = _objUserDetails.IsActive;
                       _objDetails.ModifiedBy = _objUserDetails.ModifiedBy;
                       _objDetails.ModifiedOn = _objUserDetails.ModifiedOn;
                        db.tblUsers.Add(_objDetails);
                        db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdatePassword(UserDetails masterUser)
        {
            try
            {
                using (AIMFinServDBEntities db = new AIMFinServDBEntities())
                {
                    var GetPasswordEntity = db.tblUsers.Where(p => p.UserGuid == masterUser.UserGuid).FirstOrDefault();
                    if (GetPasswordEntity != null)
                    {
                        GetPasswordEntity.Password = masterUser.Password;
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
