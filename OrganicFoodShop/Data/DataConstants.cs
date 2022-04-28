namespace OrganicFoodShop.Data
{
    public class DataConstants
    {
        public class Product
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int BarcodeMaxLength = 15;
            public const int DescriptionMaxLength = 50;
        }

        public class Category
        {
            public const int NameMaxLength = 40;
        }

        public class Employee
        {
            public const int UsernameMinLength = 3;
            public const int UsernameMaxLength = 20;
            public const int PositionMinLength = 3;
            public const int PositionMaxLength = 20;
        }

        public class User
        {
            public const int FullNameMaxLength = 40;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }
    }
}