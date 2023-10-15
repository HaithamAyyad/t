using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Languages
{
    internal class Error
    {
        private static Error _instance;
        public static Error Instance
        {
            get { return (_instance == null) ? _instance = new Error() : _instance; }
        }

        public string MustNotStartWith  { get; set; }
        public string ThisFunctionOnlyUseFor { get; set; }
        public string MustBeBlankIfEmploymentCodeIs { get; set; }
        public string MustBeEitherZeroOrOne { get; set; }
        public string MustBeBlankOtherwiseFill { get; set; }
        public string MustBeUpperCase { get; set; }
        public string MustBeNumerical { get; set; }
        public string MustBeZeroOrEqualToOrGreaterToHousHoldForYearIfCodeH { get; set; }
        public string CantBeBlankIf { get; set; }
        public string TotalIsNotCorrect { get; set; }
        public string LengthIsNotSet { get; set; }
        public string PostionIsNotSet { get; set; }
        public string ForYear87And05 { get; set; }
        public string EmailIsEmpty { get; set; }
        public string EmailIsNotCorrect { get; set; }
        public string CantBeEmpty { get; set; }
        public string MoneyOriginalMustNotSameAsCorrect { get; set; }
        public string MustBeEither98Or99 { get; set; }
        public string IsNotValidAgentIndicator { get; set; }
        public string IsNotValidEmploymentCode { get; set; }
        public string MustEnterBlanksIfNoCorrections { get; set; }
        public string MustBeAddedTo { get; set; }
        public string CountryCodeIsNotCorrect { get; set; }
        public string RecordsShouldNotExceed { get; set; }
        public string NotCorrectMoneyData { get; set; }
        public string IfYear2023ValueMustNotExceed { get; set; }
        public string PostionAndLengthIsNotCorrect { get; set; }
        public string LengthExceeds { get; set; }
        public string LenghtMustBeExactly { get; set; }
        public string IsNotDefined { get; set; }
        public string FieldMustBe { get; set; }
        public string StateCodeIsNotValid { get; set; }
        public string InvalidClass { get; set; }
        public string DoesntBelongTo { get; set; }
        public string IsEmpty { get; set; }
        public string AlreadyAddedIn { get; set; }
        public string SharedWithSamePosition { get; set; }
        public string PositionAddedMoreThanOnceInBlankList { get; set; }
        public string HasNoFieldOrNotAddedToBlankList { get; set; }
        public string AlreadyAddedTo { get; set; }
        public string MustBeBlank { get; set; }
        public string FieldIsRequired { get; set; }
        public string TaxYearIsNotSupported { get; set; }
        public string DocumentIsClosed { get; set; }
        public string DocumentIsOpened { get; set; }
        public string AtLeastOneEmployerRecordShouldBeProvided { get; set; }
        public string FileIsNotCorrect { get; set; }
        public string FileIsNotExists { get; set; }
        public string InvaildFile { get; set; }
        public string IsNotProvided { get; set; }
        public string CreateManagerFaild { get; set; }
        public string PreparerCodeIsNotValid { get; set; }
        public string IsNotValidResubWageFile { get; set; }
        public string IsNotVaildKindOfEmployer { get; set; }
        public string MustBeEqualOrGraterThanTheSumOf { get; set; }
        public string CantBeBlank { get; set; }
        public string NumberOfEmployeeRecordsIsNotCorrect { get; set; }
        public string NumberOfEmployeeOptionalRecordsIsNotCorrect { get; set; }
        public string MustNotExceedSocialSecurityMaxTaxedEarnings { get; set; }
        public string Remove { get; set; }

        public Error()
        {
            MustNotStartWith = Language.Instance.LoadExceptionString("Must_Not_Start_With");
            ThisFunctionOnlyUseFor = Language.Instance.LoadExceptionString("This_Function_Only_Use_For");
            MustBeBlankIfEmploymentCodeIs = Language.Instance.LoadExceptionString("Must_Be_Blank_If_EmploymentCode_Is");
            MustBeEitherZeroOrOne = Language.Instance.LoadExceptionString("Must_Be_Either_Zero_Or_One");
            MustBeBlankOtherwiseFill = Language.Instance.LoadExceptionString("Must_Be_Blank_Otherwise_Fill");
            MustBeUpperCase = Language.Instance.LoadExceptionString("Must_Be_UpperCase");
            MustBeNumerical = Language.Instance.LoadExceptionString("Must_Be_Numerical");
            MustBeZeroOrEqualToOrGreaterToHousHoldForYearIfCodeH = Language.Instance.LoadExceptionString("Must_Be_Zero_OrEqual_To_OrGreater_ToHousHold_For_Year_If_Code_H");
            CantBeBlankIf = Language.Instance.LoadExceptionString("Cant_Be_Blank_If");
            TotalIsNotCorrect = Language.Instance.LoadExceptionString("Total_Is_Not_Correct");
            LengthIsNotSet = Language.Instance.LoadExceptionString("Length_Is_Not_Set");
            PostionIsNotSet = Language.Instance.LoadExceptionString("Postion_Is_Not_Set");
            ForYear87And05 = Language.Instance.LoadExceptionString("For_Year_87_And_05");
            EmailIsEmpty = Language.Instance.LoadExceptionString("Email_Is_Empty");
            EmailIsNotCorrect = Language.Instance.LoadExceptionString("Email_Is_Not_Correct");
            CantBeEmpty = Language.Instance.LoadExceptionString("Cant_Be_Empty");
            MoneyOriginalMustNotSameAsCorrect = Language.Instance.LoadExceptionString("Money_Original_Must_Not_SameAs_Correct");
            MustBeEither98Or99 = Language.Instance.LoadExceptionString("Must_Be_Either_98Or99");
            IsNotValidAgentIndicator = Language.Instance.LoadExceptionString("Is_Not_Valid_Agent_Indicator");
            IsNotValidEmploymentCode = Language.Instance.LoadExceptionString("Is_Not_Valid_Employment_Code");
            MustEnterBlanksIfNoCorrections = Language.Instance.LoadExceptionString("Must_Enter_Blanks_IfNo_Corrections");
            MustBeAddedTo = Language.Instance.LoadExceptionString("Must_Be_AddedTo");
            CountryCodeIsNotCorrect = Language.Instance.LoadExceptionString("CountryCode_IsNot_Correct");
            RecordsShouldNotExceed = Language.Instance.LoadExceptionString("Records_Should_Not_Exceed");
            NotCorrectMoneyData = Language.Instance.LoadExceptionString("Not_Correct_MoneyData");
            IfYear2023ValueMustNotExceed = Language.Instance.LoadExceptionString("If_Year2023_Value_Must_NotExceed");
            PostionAndLengthIsNotCorrect = Language.Instance.LoadExceptionString("Postion_And_Length_IsNot_Correct");
            LengthExceeds = Language.Instance.LoadExceptionString("Length_Exceeds");
            LenghtMustBeExactly = Language.Instance.LoadExceptionString("Lenght_MustBe_Exactly");
            IsNotDefined = Language.Instance.LoadExceptionString("IsNot_Defined");
            FieldMustBe = Language.Instance.LoadExceptionString("Field_MustBe");
            StateCodeIsNotValid = Language.Instance.LoadExceptionString("StateCode_IsNot_Valid");
            InvalidClass = Language.Instance.LoadExceptionString("Invalid_Class");
            DoesntBelongTo = Language.Instance.LoadExceptionString("Doesnt_BelongTo");
            IsEmpty = Language.Instance.LoadExceptionString("IsEmpty");
            AlreadyAddedIn = Language.Instance.LoadExceptionString("Already_Added_In");
            SharedWithSamePosition = Language.Instance.LoadExceptionString("Shared_WithSame_Position");
            PositionAddedMoreThanOnceInBlankList = Language.Instance.LoadExceptionString("Position_AddedMore_ThanOnce_InBlankList");
            HasNoFieldOrNotAddedToBlankList = Language.Instance.LoadExceptionString("HasNo_Field_OrNot_AddedTo_BlankList");
            AlreadyAddedTo = Language.Instance.LoadExceptionString("Already_Added_To");
            MustBeBlank = Language.Instance.LoadExceptionString("Must_Be_Blank");
            FieldIsRequired = Language.Instance.LoadExceptionString("Field_Is_Required");
            TaxYearIsNotSupported = Language.Instance.LoadExceptionString("TaxYear_IsNot_Supported");
            DocumentIsClosed = Language.Instance.LoadExceptionString("Document_Is_Closed");
            DocumentIsOpened = Language.Instance.LoadExceptionString("Document_Is_Opened");
            AtLeastOneEmployerRecordShouldBeProvided = Language.Instance.LoadExceptionString("AtLeast_OneEmployer_Record_ShouldBe_Provided");
            FileIsNotCorrect = Language.Instance.LoadExceptionString("File_IsNot_Correct");
            FileIsNotExists = Language.Instance.LoadExceptionString("File_IsNot_Exists");
            InvaildFile = Language.Instance.LoadExceptionString("Invaild_File");
            IsNotProvided = Language.Instance.LoadExceptionString("IsNot_Provided");
            CreateManagerFaild = Language.Instance.LoadExceptionString("Create_Manager_Faild");
            PreparerCodeIsNotValid = Language.Instance.LoadExceptionString("PreparerCode_IsNot_Valid");
            IsNotValidResubWageFile = Language.Instance.LoadExceptionString("IsNot_Valid_Resub_Wage_File");
            IsNotVaildKindOfEmployer = Language.Instance.LoadExceptionString("IsNot_Vaild_KindOfEmployer");
            MustBeEqualOrGraterThanTheSumOf = Language.Instance.LoadExceptionString("Must_Be_EqualOr_GraterThan_TheSum_Of");
            CantBeBlank = Language.Instance.LoadExceptionString("Cant_Be_Blank");
            NumberOfEmployeeRecordsIsNotCorrect = Language.Instance.LoadExceptionString("NumberOf_Employee_Records_IsNot_Correct");
            NumberOfEmployeeOptionalRecordsIsNotCorrect = Language.Instance.LoadExceptionString("NumberOf_EmployeeOptional_Records_IsNotCorrect");
            MustNotExceedSocialSecurityMaxTaxedEarnings = Language.Instance.LoadExceptionString("Must_Not_Exceed_SocialSecurity_MaxTaxedEarnings");
            Remove = Language.Instance.LoadExceptionString("Remove");
        }

        public string GetInternalError(string className, string error)
        {
            return $"{Language.Instance.LoadExceptionString("Internal_Error")},{className} {error}";
        }

        public string GetInternalError<T>(string className, string error, T value)
        {
            return $"{Language.Instance.LoadExceptionString("Internal_Error")},{className} {error} {value}";
        }

        public string GetError(string className, string error)
        {
            return $"{className} {error}";
        }

        public string GetError<T>(string className, string error, T value)
        {
            return $"{className} {error} {value}";
        }
    }
}
