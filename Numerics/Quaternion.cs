using System;
using Guardian.Mutatio;

namespace Guardian.Numerics
{
    public class Quaternion<TNum> : NTuple<TNum> where TNum : unmanaged
    {
        public static Quaternion<TNum> EulerAngles(Vector3<TNum> euler)
        {
            throw new NotImplementedException();
        }

        public static Quaternion<TNum> AxisRotation(Vector<TNum> axis, TNum angle)
        {
            var quaternion = axis.Normalize().Quaternion();
            quaternion.W = angle;
            return quaternion;
        }

        public Quaternion(TNum x, TNum y, TNum z, TNum w) : base(4)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Quaternion(NTuple<TNum> tuple) : base((tuple as IAccessor<TNum>).Mutable, tuple.Stack())
        {
            if (Size != 4)
                throw new ArgumentException("Illegal Quaternion Size: " + Size);
        }

        #region X Y Z W Accessors

        public const int IndexX = 0;
        public const int IndexY = 1;
        public const int IndexZ = 2;
        public const int IndexW = 3;

        public RefStack<TNum> StackX => Stack(IndexX);
        public RefStack<TNum> StackY => Stack(IndexY);
        public RefStack<TNum> StackZ => Stack(IndexZ);
        public RefStack<TNum> StackW => Stack(IndexW);

        public TNum X
        {
            get => StackX.Get();
            set => StackX.Set(value);
        }

        public TNum Y
        {
            get => StackY.Get();
            set => StackY.Set(value);
        }

        public TNum Z
        {
            get => StackZ.Get();
            set => StackZ.Set(value);
        }

        public TNum W
        {
            get => StackW.Get();
            set => StackW.Set(value);
        }

        #endregion

        #region Advanced Arithmetic Accessors
        /*
        public Vector3<TNum> Forward() => new Vector3<TNum>(
            2 * (this.X * this.Z + this.W * this.Y),
            2 * (this.Y * this.Z - this.W * this.X),
            1 - 2 * (this.X * this.X + this.Y * this.Y)
        );

        public Vector3<TNum> Up() => new Vector3<TNum>(
            2 * (this.X * this.Y - this.W * this.Z),
            1 - 2 * (this.X * this.X + this.Z * this.Z),
            2 * (this.Y * this.Z + this.W * this.X)
        );

        public Vector3<TNum> Left() => new Vector3<TNum>(
            1 - 2 * (this.Y * this.Y + this.Z * this.Z),
            2 * (this.X * this.Y + this.W * this.Z),
            2 * (this.X * this.Z - this.W * this.Y)
        );

        public Vector3<TNum> EulerAngles()
        {
            // https://stackoverflow.com/questions/11492299/quaternion-to-euler-angles-algorithm-how-to-convert-to-y-up-and-between-ha

            // Store the Euler angles in radians
            Vector3<TNum> pitchYawRoll = new Vector3<TNum>();

            double sthisw = this.W * this.W;
            double sthisx = this.X * this.X;
            double sthisy = this.Y * this.Y;
            double sthisz = this.Z * this.Z;

            // If thisuaternion is normalised the unit is one, otherwise it is the correction factor
            double unit = sthisx + sthisy + sthisz + sthisw;
            double test = this.X * this.Y + this.Z * this.W;

            if (test > 0.4999f * unit) // 0.4999f OR 0.5f - EPSILON
            {
                // Singularity at north pole
                pitchYawRoll.Y = 2f * (float)Math.Atan2(this.X, this.W); // Yaw
                pitchYawRoll.X = MathF.PI * 0.5f; // Pitch
                pitchYawRoll.Z = 0f; // Roll
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit) // -0.4999f OR -0.5f + EPSILON
            {
                // Singularity at south pole
                pitchYawRoll.Y = -2f * (float)Math.Atan2(this.X, this.W); // Yaw
                pitchYawRoll.X = -MathF.PI * 0.5f; // Pitch
                pitchYawRoll.Z = 0f; // Roll
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * this.X * this.W + 2f * this.Y * this.Z, 1 - 2f * (sthisz + sthisw)); // Yaw 
                pitchYawRoll.X = (float)Math.Asin(2f * (this.X * this.Z - this.W * this.Y)); // Pitch 
                pitchYawRoll.Z = (float)Math.Atan2(2f * this.X * this.Y + 2f * this.Z * this.W, 1 - 2f * (sthisy + sthisz)); // Roll 
            }

            return pitchYawRoll;
        }
        */
        #endregion
    }

    #region Subtypes

    public class QuaternionF : Quaternion<float>
    {
        public QuaternionF(float x, float y, float z, float w) : base(x, y, z, w)
        {
        }
    }

    public class QuaternionD : Quaternion<double>
    {
        public QuaternionD(double x, double y, double z, double w) : base(x, y, z, w)
        {
        }
    }

    #endregion
}