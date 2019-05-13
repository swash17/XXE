using System;
using System.Windows.Forms;



namespace XXE_UserInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplashScreen());
        }

        /*
        public static void InitializeVars()
        {
            private static bool PropFormDisplayed = false;
            private static bool LinkFormDisplayed = false;
            private static bool ODFormDisplayed = false;
        }
        */
    }

    public static class ValidateData
    {
        //code to check if data input into data grids are valid

        // IsNumeric Function
        public static bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        // IsUnsignedInteger Function
        public static bool IsUInt16(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isUInt16;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            ushort retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its integer number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isUInt16 = UInt16.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isUInt16;
        }
    }

}