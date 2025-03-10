namespace Templet.Data.AppMetaData
{
    public static class Router
    {
        private const string SingleRoute = "{id}";
        private const string ListRoute = "List";


        private const string root = "Api";
        private const string version = "V1";
        private const string Rule = root + "/" + version;

        public static class ProjectRouting
        {
            private const string Prefix = Rule + "/" + "Project/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string GetByProjectId = Prefix + "GetTaskByProject/{id}";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class SpecialDays
        {
            private const string Prefix = Rule + "/" + "SpecialDays/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class ExtraDeductionRouting
        {
            private const string Prefix = Rule + "/" + "ExtraDeduction/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string GetByEmployeeId = Prefix + "GetExtraDeductionByEmployeeId/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class Department
        {
            private const string Prefix = Rule + "/" + "Department/";
            public const string GetDepartmentByEmployee = Prefix + "GetDepartmentByEmployee/{id}";
            public const string GetEmployeesInDepartment = Prefix + "GetEmployeesInDepartment/{id}";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string GetDepartmentbyParentDep = Prefix + "GetDepartmentbyParentDep/{id}";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class NationalVacation
        {
            private const string Prefix = Rule + "/" + "NationalVacation/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string GetByDate = Prefix + "GetbyDate/{date}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class AttendanceRouting
        {
            private const string Prefix = Rule + "/" + "Attendance/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string GetByEmployeeId = Prefix + "GetByEmployeeId/{id}";
            public const string GetAttendanceHistoryByEmployeeId = Prefix + "AttendanceHistory/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class RaiseRouting
        {
            private const string Prefix = Rule + "/" + "Raise/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class ExpectedPaymentRouting
        {
            private const string Prefix = Rule + "/" + "ExpectedPayment/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string GetByProjectId = Prefix + "GetByProjectId/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class EmployeeRoleHistoryRouting
        {
            private const string Prefix = Rule + "/" + "EmployeeRoleHistory/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class EmployeeSalaryHistoryRouting
        {
            private const string Prefix = Rule + "/" + "EmployeeSalaryHistory/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class SubProjectRouting
        {
            private const string Prefix = Rule + "/" + "SubProject/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string EditTasks = Prefix + "EditTaskInSubProject";
            public const string GetByProjectId = Prefix + "GetSubProjectByProject/{id}";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class ClientRouting
        {
            private const string Prefix = Rule + "/" + "Client/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class ExtraBonuesRouting
        {
            private const string Prefix = Rule + "/" + "ExtraBonues/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class OvertimeRouting
        {
            private const string Prefix = Rule + "/" + "Overtime/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class LeaveType
        {
            private const string Prefix = Rule + "/" + "LeaveType/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }

        public static class LeaveRequestRouting
        {
            private const string Prefix = Rule + "/" + "LeaveRequest/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string EditStatus = Prefix + "EditStatus";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class TaskRouting
        {
            private const string Prefix = Rule + "/" + "Task/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string GetBySubProjectId = Prefix + "GetTaskBySubProject/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string UpdateHour = Prefix + "UpdateHour";
            public const string GetByEmployeeId = Prefix + "GetByEmployeeId/{id}";
            public const string GetByDepartmentId = Prefix + "GetByDepartmentId/{id}";
        }

        public static class ProjectFinancialRouting
        {
            private const string Prefix = Rule + "/" + "ProjectFinancialData/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }

        public static class TaskWorkLogRouting
        {
            private const string Prefix = Rule + "/" + "TaskWorkLog/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }

        public static class AbsenceRouting
        {
            private const string Prefix = Rule + "/" + "Absence/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }

        public static class ProbationPeriodRouting
        {
            private const string Prefix = Rule + "/" + "ProbationPeriod/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class EmployeeAttachmentRouting
        {
            private const string Prefix = Rule + "/" + "EmployeeAttachment/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class EmailRouting
        {
            private const string Prefix = Rule + "/" + "Email/";
            public const string SendEmail = Prefix + "SendEmail";

        }
        public static class UserRouting
        {
            private const string Prefix = Rule + "/" + "AppUser/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
        }
        public static class AuthenticationRouting
        {
            private const string Prefix = Rule + "/" + "Authentication/";
            public const string SginIn = Prefix + "SginIn";
            public const string ConfirmEmail = Prefix + "ConfirmEmail";
        }
        public static class AuthorizationRouting
        {
            private const string Prefix = Rule + "/" + "Authorization/";
            public const string CreateRole = Prefix + "CreateRole";
            public const string MangeUserRoles = Prefix + "mange-user-roles/{userId}";
            public const string GetRolesList = Prefix + "GetRolesList";
            public const string GetClimsList = Prefix + "GetClaimsList";
            public const string MangeUserClaims = Prefix + "mange-user-calims/{userId}";
            public const string UpdateRole = Prefix + "UpdateRole";
            public const string UpdateClaims = Prefix + "UpdateClaims";

        }
    }
}
