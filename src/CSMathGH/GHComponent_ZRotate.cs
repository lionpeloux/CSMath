using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using CSMath;

namespace CSMathGH
{
    public class GHComponent_ZRotate : GH_Component
    {

        public GHComponent_ZRotate()
            : base("Z-Rotate a Plane", "ZRotate",
                "Rotate a Plane around it's Normal.",
                "TMarsupilami", "Math")
        {
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("{5030DA03-91E8-449A-B26D-0490C5F1AA3A}"); }
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Plane", "plane", "", GH_ParamAccess.item);
            pManager.AddNumberParameter("Angle", "alpha", "", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.Register_PlaneParam("plane", "plane", "");
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Plane plane = new Plane();
            double alpha = 0;

            DA.GetData(0, ref plane);
            DA.GetData(1, ref alpha);

            Frame f = Utility.ToFrame(plane);
            f = Frame.ZRotate(f, alpha);

            DA.SetData(0, Utility.ToPlane(f));
        }


        

    }
}
