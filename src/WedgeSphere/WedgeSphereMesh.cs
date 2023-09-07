// Original code (unlicensed): https://github.com/mrvux/FeralTic/blob/master/Core/DX11/Geometry/Primitives/DX11Primitive_Sphere.cs
// FeralTic Copyright (C) Julien Vulliet

using Stride.Core;
using Stride.Graphics;
using Stride.Core.Mathematics;
using Stride.Rendering.ProceduralModels;

namespace VL.Stride.Rendering.Models
{
    // The annotations don't do anything for now
    //[DataContract("WedgeSphereMesh")]
    //[Display("CycleSphereMesh")] // This name shows up in the procedural model dropdown list
    public class WedgeSphereMesh : PrimitiveProceduralModelBase
    {
        //[DataMember(10)]
        public float Radius { get; set; } = 0.5f;

        //[DataMember(11)]
        public int ResolutionX { get; set; } = 3;
        
        //[DataMember(12)]
        public int ResolutionY { get; set; } = 3;

        //[DataMember(13)]
        public float CyclesX { get; set; } = 1.0f;

        //[DataMember(14)]
        public float CyclesY { get; set; } = 1.0f;


        private const float pi = MathUtil.Pi;
        private const float pidiv2 = MathUtil.PiOverTwo;
        private const float twopi = MathUtil.TwoPi;


        protected override GeometricMeshData<VertexPositionNormalTexture> CreatePrimitiveMeshData()
        {

            float radius = Radius;
            int resX = ResolutionX;
            int resY = ResolutionY;
            float cx = CyclesX;
            float cy = CyclesY;

            List<VertexPositionNormalTexture> vertices = new List<VertexPositionNormalTexture>();
            List<int> indices = new List<int>();

            for (int i = 0; i <= resY; i++)
            {
                float v = 1 - (float)i / resY;

                float latitude = (i * pi / resY) - pidiv2;

                float dy = (float)Math.Sin(latitude * cy);
                float dxz = (float)Math.Cos(latitude * cy);

                // Create a single ring of vertices at this latitude.
                for (int j = 0; j <= resX; j++)
                {
                    float u = (float)j / resX;

                    float longitude = j * twopi / resX;

                    float dx = (float)Math.Sin(longitude * cx);
                    float dz = (float)Math.Cos(longitude * cx);

                    dx *= dxz;
                    dz *= dxz;

                    VertexPositionNormalTexture vertex = new VertexPositionNormalTexture();
                    vertex.Position = new Vector3(dx * radius, dy * radius, dz * radius);
                    vertex.Normal = Vector3.Normalize(new Vector3(vertex.Position.X, vertex.Position.Y, vertex.Position.Z));
                    vertex.TextureCoordinate = new Vector2(u, v);

                    vertices.Add(vertex);
                }
            }

            int stride = resX + 1;

            for (int i = 0; i < resY; i++)
            {
                for (int j = 0; j <= resX; j++)
                {
                    int nextI = i + 1;
                    int nextJ = (j + 1) % stride;

                    indices.Add(i * stride + j);
                    indices.Add(nextI * stride + j);
                    indices.Add(i * stride + nextJ);
                    

                    indices.Add(i * stride + nextJ);
                    indices.Add(nextI * stride + j);
                    indices.Add(nextI * stride + nextJ);
                    
                }
            }

            return new GeometricMeshData<VertexPositionNormalTexture>(vertices.ToArray(), indices.ToArray(), isLeftHanded: false) { Name = "WedgeSphereMesh" };
        }
    }
}