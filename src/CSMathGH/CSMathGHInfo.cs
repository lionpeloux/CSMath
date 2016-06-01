using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace CSMathGH
{
    public class CSMathGHInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "CSMathGH";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("e11d6905-9417-4300-b206-ffcc49f2a010");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
