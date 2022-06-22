using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public enum EnumMessage
    {
        [Description("Có lỗi xảy ra trong quá trình xử lý. Vui lòng thử lại sau.")]
        ERROR = -1,
        [Description("Tài khoản này chưa được cấu hình để sử dụng hệ thống CRM.")]
        NOT_FOUND_ACCOUNT = -2,
        [Description("Tài khoản này không liên kết với nhân viên trên hệ thống CRM.")]
        NOT_FOUND_EMPLOYEE = -3,
        [Description("Không tìm thấy dữ liệu")]
        NOT_FOUND = -5
    }

    public enum ENUM_WORKSPACE_TYPE
    {
        [Description("Kinh doanh")]
        Business = 1,
        [Description("Điều hành")]
        Operating = 2,
        [Description("Kỹ thuật - CNTT")]
        IT = 3
    }

    public enum ResponseStatusCode
    {
        Error = -1,
        Success = 1,
        Warning = 0,
        Special = 2
    }

    public static class EnumExtensionMethod
    {
        public static string GetDescription(this Enum value, bool resource = false)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                            Attribute.GetCustomAttribute(field,
                                typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        if (resource)
                        {
                            return "";
                        }
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
