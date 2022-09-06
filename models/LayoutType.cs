using System;


namespace gokart_vanal.models
{
	[Serializable()]
	public enum LayoutType
	{
		ArrangeVertically,
		ArrangeHorizontally
	}
    public static class LayoutTypeStatic
    {


        public static int ToIndex(this LayoutType layoutType)
        {
            switch (layoutType)
            {
                default:
                case LayoutType.ArrangeVertically:
                    return 0;
                case LayoutType.ArrangeHorizontally:
                    return 1;
            }
        }

        public static LayoutType FromIndex(int n)
        {
            switch (n)
            {
                default:
                case 0:
                    return LayoutType.ArrangeVertically;
                case 1:
                    return LayoutType.ArrangeHorizontally;
            }
        }
    }
}
