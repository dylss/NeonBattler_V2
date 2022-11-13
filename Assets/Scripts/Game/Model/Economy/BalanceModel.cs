using System;

namespace Model.Economy
{
	/// <summary>
	/// A basic model for in game currency
	/// </summary>
	public class BalanceModel
	{
		/// <summary>
		/// How much currency there currently is
		/// </summary>
		public int CurrentBalance { get; private set; }

		/// <summary>
		/// Occurs when balance changed.
		/// </summary>
		public event Action balanceChanged;

		/// <summary>
		/// Initializes a new instance of the <see cref="Core.Economy.Balance" /> class.
		/// </summary>
		public BalanceModel(int startingBalance)
		{
			ChangeBalance(startingBalance);
		}

		/// <summary>
		/// Adds the balance.
		/// </summary>
		/// <param name="increment">the change in balance</param>
		public void AddBalance(int increment)
		{
			ChangeBalance(increment);
		}

		/// <summary>
		/// Method for trying to purchase, returns false for insufficient funds
		/// </summary>
		/// <returns><c>true</c>, if purchase was successful i.e. enough balance <c>false</c> otherwise.</returns>
		public bool TryPurchase(int cost)
		{
			// Cannot afford this item
			if (!CanAfford(cost))
			{
				return false;
			}
			ChangeBalance(-cost);
			return true;
		}

		/// <summary>
		/// Determines if the specified cost is affordable.
		/// </summary>
		/// <returns><c>true</c> if this cost is affordable; otherwise, <c>false</c>.</returns>
		public bool CanAfford(int cost)
		{
			return CurrentBalance >= cost;
		}

		/// <summary>
		/// Changes the balance.
		/// </summary>
		/// <param name="increment">the change in balance</param>
		protected void ChangeBalance(int increment)
		{
			if (increment != 0)
			{
				CurrentBalance += increment;
				if (balanceChanged != null)
				{
					balanceChanged();
				}
			}
		}
    }
}