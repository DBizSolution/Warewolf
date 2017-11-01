﻿using System;
using System.Collections.Generic;

namespace Dev2.Common.Interfaces
{

    public interface IConflict
    {
        bool HasConflict { get; set; }
        bool IsChecked { get; set; }
        Guid UniqueId { get; set; }
    }

    public interface IMergeArmConnectorConflict : IEquatable<IMergeArmConnectorConflict>
    {
        string ArmDescription { get; set; }
        string SourceUniqueId { get; set; }
        string DestinationUniqueId { get; set; }
        string Key { get; set; }
    }

    public interface IArmConnectorConflict : IConflict
    {
        IMergeArmConnectorConflict CurrentArmConnector { get; set; }
        IMergeArmConnectorConflict DifferentArmConnector { get; set; }
    }

    public interface IToolConflict:IConflict
    {
        IMergeToolModel CurrentViewModel { get; set; }
        IMergeToolModel DiffViewModel { get; set; }
        LinkedList<IToolConflict> Children { get; set; }
        IToolConflict Parent { get; set; }        
        bool IsMergeExpanderEnabled { get; set; }
        bool IsMergeExpanded { get; set; }        
        bool IsContainerTool { get; set; }
        IToolConflict GetNextConflict();
        LinkedListNode<IToolConflict> Find(IToolConflict itemToFind);
        bool All(Func<IToolConflict, bool> check);
    }
}