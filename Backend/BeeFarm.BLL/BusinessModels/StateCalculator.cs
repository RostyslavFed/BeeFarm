using BeeFarm.DAL.Entity;
using System;

namespace BeeFarm.BLL.BusinessModels
{
	public class StateCalculator
	{
		public State GetState(AverageStatistic averageStatistic, Beehive beehive)
		{
			var recommendedTemperature = beehive.RecommendedTemperature;
			var recommendedHumidity = beehive.RecommendedHumidity;

			var valueState = TemperatureDeviation(recommendedTemperature, averageStatistic.AverageTemperature) +
				HumidityDeviation(recommendedHumidity, averageStatistic.AverageHumidity);

			valueState = MapValue(valueState);

			return new State(valueState);
		}

		private int TemperatureDeviation(double recomendedTemperature, double averageTemperature)
		{
			var percentDeviation = (int) Math.Abs(((averageTemperature / recomendedTemperature) - 1) * 100);
			return percentDeviation;
		}

		private int HumidityDeviation(int recomendedHumidity, int averageHumidity)
		{
			double dd = ((double)averageHumidity / (double)recomendedHumidity);
			var percentDeviation = (int) Math.Abs((dd - 1) * 100);
			return percentDeviation;
		}

		private int MapValue(int value)
		{
			//from 0-100 in 100-0
			return 100 - value;
		}
	}
}
