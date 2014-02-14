
namespace GameOfLife
{
    public interface ICellIterator : IIterator<Cell>
    {
        void SetHomeCell(Cell homeCell);
    }
}
