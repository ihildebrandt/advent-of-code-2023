namespace Day03;

public record Position(Coordinate TopLeft, Coordinate BottomRight)
{
    public bool IsAdjacentTo(Position position)
    {
        var test = new Position(
            new Coordinate(
                TopLeft.X - 1,
                TopLeft.Y - 1
            ),
            new Coordinate(
                BottomRight.X + 1,
                BottomRight.Y + 1
            )
        );
        
        return test.Intersects(position);
    }

    public bool Contains(Position position) 
    {
        return  TopLeft.Y <= position.TopLeft.Y &&
                TopLeft.X <= position.TopLeft.X &&
                BottomRight.Y >= position.BottomRight.Y &&
                BottomRight.X >= position.BottomRight.X;
    }

    public bool Intersects(Position position)
    {
        return 
            TopLeft.X <= position.BottomRight.X && BottomRight.X >= position.TopLeft.X &&
            TopLeft.Y <= position.BottomRight.Y && BottomRight.Y >= position.TopLeft.Y
            ;
            // TopLeft.Y < BottomRight.Y 
    }
}