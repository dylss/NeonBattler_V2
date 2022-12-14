using System;
using Model.Economy;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Component.UI
{
	/// <summary>
	/// A button controller for spawning towers
	/// </summary>
	[RequireComponent(typeof(RectTransform))]
	public class TowerSpawnButton : MonoBehaviour, IDragHandler
	{
		/// <summary>
		/// The text attached to the button
		/// </summary>
		public Text buttonText;

		public Button buyButton;


		/// <summary>
		/// Fires when the button is tapped
		/// </summary>
		public event Action<BattleObjectController> buttonTapped;

		/// <summary>
		/// Fires when the pointer is outside of the button bounds
		/// and still down
		/// </summary>
		public event Action<BattleObjectController> draggedOff;

		/// <summary>
		/// The battleobject controller that defines the button
		/// </summary>
		BattleObjectController m_Tower;

		/// <summary>
		/// Cached reference to level currency
		/// </summary>
		BalanceModel balance;

		/// <summary>
		/// The attached rect transform
		/// </summary>
		RectTransform m_RectTransform;

		/// <summary>
		/// Checks if the pointer is out of bounds
		/// and then fires the draggedOff event
		/// </summary>
		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!RectTransformUtility.RectangleContainsScreenPoint(m_RectTransform, eventData.position))
			{
				if (draggedOff != null)
				{
					draggedOff(m_Tower);
				}
			}
		}

		// /// <summary>
		// /// Define the button information for the tower
		// /// </summary>
		// /// <param name="towerData">
		// /// The tower to initialize the button with
		// /// </param>
		// public void InitializeButton(Tower towerData)
		// {
		// 	m_Tower = towerData;
		//
		// 	if (towerData.levels.Length > 0)
		// 	{
		// 		TowerLevel firstTower = towerData.levels[0];
		// 		buttonText.text = firstTower.cost.ToString();
		// 		towerIcon.sprite = firstTower.levelData.icon;
		// 	}
		// 	else
		// 	{
		// 		Debug.LogWarning("[Tower Spawn Button] No level data for tower");
		// 	}
		//
		// 	if (LevelManager.instanceExists)
		// 	{
		// 		m_Currency = LevelManager.instance.currency;
		// 		m_Currency.currencyChanged += UpdateButton;
		// 	}
		// 	else
		// 	{
		// 		Debug.LogWarning("[Tower Spawn Button] No level manager to get currency object");
		// 	}
		//
		// 	UpdateButton();
		// }
		//
		// /// <summary>
		// /// Cache the rect transform
		// /// </summary>
		// protected virtual void Awake()
		// {
		// 	m_RectTransform = (RectTransform) transform;
		// }
		//
		// /// <summary>
		// /// Unsubscribe from events
		// /// </summary>
		// protected virtual void OnDestroy()
		// {
		// 	if (m_Currency != null)
		// 	{
		// 		m_Currency.currencyChanged -= UpdateButton;
		// 	}
		// }
		//
		// /// <summary>
		// /// The click for when the button is tapped
		// /// </summary>
		// public void OnClick()
		// {
		// 	if (buttonTapped != null)
		// 	{
		// 		buttonTapped(m_Tower);
		// 	}
		// }
		//
		// /// <summary>
		// /// Update the button's button state based on cost
		// /// </summary>
		// void UpdateButton()
		// {
		// 	if (m_Currency == null)
		// 	{
		// 		return;
		// 	}
		//
		// 	// Enable button
		// 	if (m_Currency.CanAfford(m_Tower.purchaseCost) && !buyButton.interactable)
		// 	{
		// 		buyButton.interactable = true;
		// 		energyIcon.color = energyDefaultColor;
		// 	}
		// 	else if (!m_Currency.CanAfford(m_Tower.purchaseCost) && buyButton.interactable)
		// 	{
		// 		buyButton.interactable = false;
		// 		energyIcon.color = energyInvalidColor;
		// 	}
		// }
	}
}