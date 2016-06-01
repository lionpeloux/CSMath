using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using CSMath;

namespace CSMathGH
{
    public class GHComponent_ParallelTransport : GH_Component
    {
  
        public GHComponent_ParallelTransport()
            : base("Parallel Transport a Plane", "PT",
                "Parallel Transport a Vector",
                "TMarsupilami", "Math")
        {
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("{f189f8b8-e9af-4e88-922d-a41548a26edc}"); }
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Plane", "plane", "", GH_ParamAccess.item);
            pManager.AddPointParameter("Point", "pt", "", GH_ParamAccess.item);
            pManager.AddVectorParameter("Vector", "v", "", GH_ParamAccess.item);

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
            Point3d pt = new Point3d();
            Vector3d v = new Vector3d();

            DA.GetData(0, ref plane);
            DA.GetData(1, ref pt);
            DA.GetData(2, ref v);

            Frame f = Utility.ToFrame(plane);
            f = Frame.ParallelTransport(f, Utility.ToPoint(pt), Utility.ToVector(v));

            DA.SetData(0, Utility.ToPlane(f));
        }



    }
}
