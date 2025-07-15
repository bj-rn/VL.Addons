﻿using Stride.Core.Mathematics;
using VL.Lib.Mathematics;

namespace Bilerp;

public static class Bilerp
{
    // The MIT License
    // Copyright © 2014 Inigo Quilez
    // https://www.youtube.com/c/InigoQuilez
    // https://iquilezles.org/
    // Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    /// <summary>
    /// Inverse bilinear interpolation: given four points defining a quadrilateral, compute the uv
    /// coordinates of any point in the plane that would give result to that point as a bilinear 
    /// interpolation of the four points.
    /// The problem can be solved through a quadratic equation. More information in this <see href="https://iquilezles.org/articles/ibilinear">article</see>
    /// </summary>
    //public static Vector2 InverseBilerp(Vector2 p, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
    //{
    //    var e = b - a;
    //    var f = d - a;
    //    var g = a - b + c - d;
    //    var h = p - a;

    //    float k2 = Vector2Nodes.Cross(ref g, ref f);
    //    float k1 = Vector2Nodes.Cross(ref e, ref f) + Vector2Nodes.Cross(ref h, ref g);
    //    float k0 = Vector2Nodes.Cross(ref h, ref e);

    //    if (Math.Abs(k2) < 0.001)
    //    {
    //        return new Vector2((h.X * k1 + f.X * k0) / (e.X * k1 - g.X * k0), -k0 / k1);
    //    }
    //    else
    //    {
    //        {
    //            float w = k1 * k1 - 4.0f * k0 * k2;
    //            if (w < 0.0) return new Vector2(-1.0f, -1.0f);
    //            w = (float)Math.Sqrt(w);

    //            float ik2 = 0.5f / k2;
    //            float v = (-k1 - w) * ik2;
    //            float u = (h.X - f.X * v) / (e.X + g.X * v);

    //            if (u < 0.0 || u > 1.0 || v < 0.0 || v > 1.0)
    //            {
    //                v = (-k1 + w) * ik2;
    //                u = (h.X - f.X * v) / (e.X + g.X * v);
    //            }

    //            return new Vector2(u, v);

    //        }
    //    }
    //}


    // fixed version taken from https://gist.github.com/ivanpopelyshev/2a75479075286deb8ee5dc1fb2e07f09
    public static Vector2 InverseBilerp(Vector2 p, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
    {
        var e = b - a;
        var f = d - a;
        var g = a - b + c - d;
        var h = p - a;

        float k2 = Vector2Nodes.Cross(ref g, ref f);
        float k1 = Vector2Nodes.Cross(ref e, ref f) + Vector2Nodes.Cross(ref h, ref g);
        float k0 = Vector2Nodes.Cross(ref h, ref e);

        float k2u = Vector2Nodes.Cross(ref e, ref g);
        float k1u = Vector2Nodes.Cross(ref e, ref f) + Vector2Nodes.Cross(ref g, ref h);
        float k0u = Vector2Nodes.Cross(ref h, ref f);

        float v1, u1, v2, u2;

        v2 = 0.0f;
        u2 = 0.0f;

        if (Math.Abs(k2) < 1e-5)
        {
            v1 = -k0 / k1;
            u1 = (h.X - f.X * v1) / (e.X + g.X * v1);
        }
        else if (Math.Abs(k2u) < 1e-5)
        {
            u1 = k0u / k1u;
            v1 = (h.Y - e.Y * u1) / (f.Y + g.Y * u1);
        }
        else
        {
            float w = k1 * k1 - 4.0f * k0 * k2;

            if (w < 0.0) return new Vector2(-1.0f);

            w = (float) Math.Sqrt(w);

            v1 = (-k1 - w) / (2.0f * k2);
            v2 = (-k1 + w) / (2.0f * k2);
            u1 = (-k1u - w) / (2.0f * k2u);
            u2 = (-k1u + w) / (2.0f * k2u);
        }

        bool b1 = v1 > 0.0 && v1 < 1.0 && u1 > 0.0 && u1 < 1.0;
        bool b2 = v2 > 0.0 && v2 < 1.0 && u2 > 0.0 && u2 < 1.0;

        Vector2 res = new Vector2(-1.0f);

        if (b1 && !b2) res = new Vector2(u1, v1);
        if (!b1 && b2) res = new Vector2(u2, v2);

        return res;
    }
}
