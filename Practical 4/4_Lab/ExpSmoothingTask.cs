using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
            int currentValue = 1;
            double previousValue = 1.0;

            foreach (var point in data)
            {
                if (currentValue == 1) point.ExpSmoothedY = point.OriginalY;
                else point.ExpSmoothedY = previousValue + alpha * (point.OriginalY - previousValue);

                yield return point;

                previousValue = point.ExpSmoothedY;
                currentValue++;
            }
        }
	}
}