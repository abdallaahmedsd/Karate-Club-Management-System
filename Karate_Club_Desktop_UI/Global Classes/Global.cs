using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Club.Global_Classes
{
	public class Global
	{
		/// <summary>
		/// Represents an item in a CheckedListBox.
		/// </summary>
		public class CheckListBoxItem : IEquatable<CheckListBoxItem>
		{
			public int ID;
			public string Text;

			/// <summary>
			/// Initializes a new instance of the CheckListBoxItem class.
			/// </summary>
			/// <param name="id">The ID of the item.</param>
			/// <param name="text">The text of the item.</param>
			public CheckListBoxItem(int id, string text)
			{
				ID = id;
				Text = text;
			}
			/// <summary>
			/// Returns a string representation of the item.
			/// </summary>
			/// <returns>The text of the item.</returns>
			public override string ToString() { return Text; }

			/// <summary>
			/// Determines whether the specified CheckListBoxItem is equal to the current CheckListBoxItem.
			/// </summary>
			/// <param name="other">The CheckListBoxItem to compare with the current CheckListBoxItem.</param>
			/// <returns>true if the specified CheckListBoxItem is equal to the current CheckListBoxItem; otherwise, false.</returns>
			public bool Equals(CheckListBoxItem other)
			{
				if (other == null)
				{
					throw new ArgumentNullException(nameof(other), "The parameter 'other' cannot be null.");
				}

				return (ID == other.ID && Text == other.Text);

			}

			// Override GetHashCode to ensure consistency with Equals
			public override int GetHashCode()
			{
				return ID.GetHashCode() ^ Text.GetHashCode();
			}
		}
	}
}
