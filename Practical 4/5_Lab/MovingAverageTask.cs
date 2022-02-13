using System.Collections.Generic;

namespace yield
{
	public static class MovingAverageTask
	{
		public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
		{
            var pointsQueue = new Queue<double>();
            var sumY = 0.0;

            foreach (var point in data)
            {
                if (windowWidth <= pointsQueue.Count)
                    sumY = sumY - pointsQueue.Dequeue();

                sumY = sumY + point.OriginalY;
                pointsQueue.Enqueue(point.OriginalY);
                point.AvgSmoothedY = sumY / pointsQueue.Count;
                yield return point;
            }
        }
	}
}