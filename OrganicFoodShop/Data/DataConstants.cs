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
            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 40;
            public const int UsernameMinLength = 3;
            public const int UsernameMaxLength = 20;
            public const int YearMinValue = 2010;
            public const int YearMaxValue = 2040;
        }
    }
}