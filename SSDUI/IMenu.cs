namespace SSDUI
{
    public interface IMenu
    {
        // Will Display the overall menu of the class and the choices you can make in that menu class
        void Menu();

        // This method will record the user's choice and change your menu based on their input
        string YourChoice();
    }
}