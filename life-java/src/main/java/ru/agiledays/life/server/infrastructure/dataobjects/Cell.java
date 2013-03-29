package ru.agiledays.life.server.infrastructure.dataobjects;

public class Cell {
    private int x;
    private int y;
    
    public int getX() {
        return x;
    }
    
    public void setX(final int x) {
        this.x = x;
    }
    
    public int getY() {
        return y;
    }
    
    public void setY(final int y) {
        this.y = y;
    }
    
    public boolean equals(Cell otherCell) {
        return otherCell != null && otherCell.x == x && otherCell.y == y;
    }
    
    @Override
    public boolean equals(Object other) {
        if (other != null && Cell.class.isAssignableFrom(other.getClass())) {
            return equals((Cell)other);
        }
        
        return false;
    }

    @Override
    public int hashCode() {
        return (x * 397) ^ y;
    }
    
    public Cell() {}
    
    public Cell(final int row, final int column) {
        x = column;
        y = row;
    }
}
