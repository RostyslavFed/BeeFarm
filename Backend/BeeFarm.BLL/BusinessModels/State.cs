
namespace BeeFarm.BLL.BusinessModels
{
	public class State
	{
		private const int maxValue = 100;
		private const int minValue = 0;

		public int MaxValue => maxValue;
		public int MinValue => minValue;
		public int Value { get; }

		public State(int value)
		{
			Value = value;
		}
	}
}
