namespace VektorMathematik
{
    internal struct Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector() //Standard-Constructor
        {
            x = 0f;
            y = 0f;
            z = 0f;
        }
        public Vector(float _x, float _y, float _z) //x-y-z-Constructor
        {
            x = _x; 
            y = _y; 
            z = _z;
        }

        public override string ToString() //Display Vector
        {
            return $"[ {x} | {y} | {z} ]";
        }

        public static Vector operator +(Vector _v0, Vector _v1) //Sum
        {
            var xResult = _v0.x + _v1.x;
            var yResult = _v0.y + _v1.y;
            var zResult = _v0.z + _v1.z;
            var vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public static Vector operator -(Vector _v0, Vector _v1) //Difference
        {
            var xResult = _v0.x - _v1.x;
            var yResult = _v0.y - _v1.y;
            var zResult = _v0.z - _v1.z;
            var vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public static Vector operator *(Vector _v, float _skalar) //Product
        {
            var xResult = _v.x * _skalar;
            var yResult = _v.y * _skalar;
            var zResult = _v.z * _skalar;
            var vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public static float operator *(Vector _v0, Vector _v1) //Scalar-Product
        {
            return _v0.x * _v1.x + _v0.y * _v1.y + _v0.z * _v1.z;
        }

        public Vector CrossProduct(Vector _vCross)
        {
            var xResult = y * _vCross.z - z * _vCross.y;
            var yResult = z * _vCross.x - x * _vCross.z;
            var zResult = x * _vCross.y - y * _vCross.z;
            var vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public float GetDistance(Vector _vDistance) //Distance
        {
            var difference = this - _vDistance;
            return difference.GetLength();
        }

        public static float GetDistance(Vector _v0, Vector _v1) //Static Distance
        {
            var difference = _v0 - _v1;
            return difference.GetLength();
        }

        public float GetLength() //Length
        {
            return (float)Math.Sqrt(GetSquareLength());
        }

        public float GetSquareLength () //Square-Length
        {
            return this * this;
        }
    }
}
