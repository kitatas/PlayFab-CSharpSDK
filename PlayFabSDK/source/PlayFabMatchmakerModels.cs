using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.MatchmakerModels
{
    /// <summary>
    /// This API allows the external match-making service to confirm that the user has a valid Session Ticket for the title, in
    /// order to securely enable match-making. The client passes the user's Session Ticket to the external match-making service,
    /// which then passes the Session Ticket in as the AuthorizationTicket in this call.
    /// </summary>
    [Obsolete("No longer available", false)]
    public class AuthUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Session Ticket provided by the client.
        /// </summary>
        public string AuthorizationTicket ;

    }

    [Obsolete("No longer available", false)]
    public class AuthUserResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Boolean indicating if the user has been authorized to use the external match-making service.
        /// </summary>
        public bool Authorized ;

        /// <summary>
        /// PlayFab unique identifier of the account that has been authorized.
        /// </summary>
        public string PlayFabId ;

    }

    /// <summary>
    /// A unique instance of an item in a user's inventory. Note, to retrieve additional information for an item such as Tags,
    /// Description that are the same across all instances of the item, a call to GetCatalogItems is required. The ItemID of can
    /// be matched to a catalog entry, which contains the additional information. Also note that Custom Data is only set when
    /// the User's specific instance has updated the CustomData via a call to UpdateUserInventoryItemCustomData. Other fields
    /// such as UnitPrice and UnitCurrency are only set when the item was granted via a purchase.
    /// </summary>
    [Obsolete("No longer available", false)]
    public class ItemInstance : IComparable<ItemInstance>
    {
        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation ;

        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents ;

        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or
        /// container.
        /// </summary>
        public string BundleParent ;

        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion ;

        /// <summary>
        /// A set of custom key-value pairs on the instance of the inventory item, which is not to be confused with the catalog
        /// item's custom data.
        /// </summary>
        public Dictionary<string,string> CustomData ;

        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName ;

        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration ;

        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass ;

        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId ;

        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId ;

        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate ;

        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses ;

        /// <summary>
        /// Currency type for the cost of the catalog item. Not available when granting items.
        /// </summary>
        public string UnitCurrency ;

        /// <summary>
        /// Cost of the catalog item in the given currency. Not available when granting items.
        /// </summary>
        public uint UnitPrice ;

        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy ;

        public int CompareTo(ItemInstance other)
        {
            if (other == null || other.ItemInstanceId == null) return 1;
            if (ItemInstanceId == null) return -1;
            return ItemInstanceId.CompareTo(other.ItemInstanceId);
        }

    }

    [Obsolete("No longer available", false)]
    public class PlayerJoinedRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Unique identifier of the Game Server Instance the user is joining. This must be a Game Server Instance started with the
        /// Matchmaker/StartGame API.
        /// </summary>
        public string LobbyId ;

        /// <summary>
        /// PlayFab unique identifier for the player joining.
        /// </summary>
        public string PlayFabId ;

    }

    [Obsolete("No longer available", false)]
    public class PlayerJoinedResponse : PlayFabResultCommon
    {
    }

    [Obsolete("No longer available", false)]
    public class PlayerLeftRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Unique identifier of the Game Server Instance the user is leaving. This must be a Game Server Instance started with the
        /// Matchmaker/StartGame API.
        /// </summary>
        public string LobbyId ;

        /// <summary>
        /// PlayFab unique identifier for the player leaving.
        /// </summary>
        public string PlayFabId ;

    }

    [Obsolete("No longer available", false)]
    public class PlayerLeftResponse : PlayFabResultCommon
    {
    }

    [Obsolete("No longer available", false)]
    public class UserInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Minimum catalog version for which data is requested (filters the results to only contain inventory items which have a
        /// catalog version of this or higher).
        /// </summary>
        public int MinCatalogVersion ;

        /// <summary>
        /// PlayFab unique identifier of the user whose information is being requested.
        /// </summary>
        public string PlayFabId ;

    }

    [Obsolete("No longer available", false)]
    public class UserInfoResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Array of inventory items in the user's current inventory.
        /// </summary>
        [Unordered(SortProperty="ItemInstanceId")]
        public List<ItemInstance> Inventory ;

        /// <summary>
        /// Boolean indicating whether the user is a developer.
        /// </summary>
        public bool IsDeveloper ;

        /// <summary>
        /// PlayFab unique identifier of the user whose information was requested.
        /// </summary>
        public string PlayFabId ;

        /// <summary>
        /// Steam unique identifier, if the user has an associated Steam account.
        /// </summary>
        public string SteamId ;

        /// <summary>
        /// Title specific display name, if set.
        /// </summary>
        public string TitleDisplayName ;

        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username ;

        /// <summary>
        /// Array of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency ;

        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes ;

    }

    [Obsolete("No longer available", false)]
    public class VirtualCurrencyRechargeTime
    {
        /// <summary>
        /// Maximum value to which the regenerating currency will automatically increment. Note that it can exceed this value
        /// through use of the AddUserVirtualCurrency API call. However, it will not regenerate automatically until it has fallen
        /// below this value.
        /// </summary>
        public int RechargeMax ;

        /// <summary>
        /// Server timestamp in UTC indicating the next time the virtual currency will be incremented.
        /// </summary>
        public DateTime RechargeTime ;

        /// <summary>
        /// Time remaining (in seconds) before the next recharge increment of the virtual currency.
        /// </summary>
        public int SecondsToRecharge ;

    }
}
