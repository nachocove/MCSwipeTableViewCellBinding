using System;

namespace MCSwipeTableViewCellBinding
{
    public enum MCSwipeTableViewCellState : uint
    {
        None = 0,
        State1 = 1,
        State2 = 2,
        State3 = 4,
        State4 = 8,
    }

    public enum MCSwipeTableViewCellMode : uint
    {
        None = 0,
        Exit = 1,
        Switch = 2,
    }
}

