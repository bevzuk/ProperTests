package ru.agiledays.life.server.domain;

import java.util.UUID;

public class Game {
    // NB! This field should become private after refactoring to perfect tests
    public boolean[][] Cells;
    
    private final int size;
    private final String name;
    
    public Game(final int size, final String name) {
        this.size = size;
        this.name = name;
        
        Cells = createCells();
    }
    
    public Game(final int size) {
        this.size = size;
        this.name = UUID.randomUUID().toString();
        
        Cells = createCells();
    }
    
    public int size() {
        return size;
    }
    
    public String name() {
        return name;
    }
    
    public Cell getCell(final int row, final int column) {
        return new Cell(Cells[row][column]);
    }
    
    public void giveBirth(final int row, final int column) {
        Cells[row][column] = true;
    }
    
    public void step() {
        final boolean[][] newGeneration = createCells();
        
        for (int row = 0; row < size; row++) {
            for (int column = 0; column < size; column++) {
                newGeneration[row][column] = false;
                if (getCell(row, column).isAlive() && numberOfNeighbors(row, column) < 2) {
                    newGeneration[row][column] = false;
                }
                if (getCell(row, column).isAlive() && numberOfNeighbors(row, column) == 2) {
                    newGeneration[row][column] = true;
                }
                if (getCell(row, column).isAlive() && numberOfNeighbors(row, column) == 3) {
                    newGeneration[row][column] = true;
                }
                if (getCell(row, column).isAlive() && numberOfNeighbors(row, column) == 4) {
                    newGeneration[row][column] = false;
                }
                if (getCell(row, column).isDead() && numberOfNeighbors(row, column) == 3) {
                    newGeneration[row][column] = true;
                }
            }
        }
        
        Cells = newGeneration;
    }

    @Override
    public String toString() {
        final StringBuffer sb = new StringBuffer();
        for (int row = 0; row < size; row++) {
            if (row != 0) {
                sb.append(StringHelper.newLine);
            }
            for (int column = 0; column < size; column++) {
                sb.append(getCell(row, column).isAlive() ? 'x' : '.');
            }
        }
        return sb.toString();
    }

    private int numberOfNeighbors(final int row, final int column) {
        return
            neighbor(row - 1, column - 1) +
            neighbor(row - 1, column) +
            neighbor(row - 1, column + 1) +
            neighbor(row, column - 1) +
            neighbor(row, column + 1) +
            neighbor(row + 1, column - 1) +
            neighbor(row + 1, column) +
            neighbor(row + 1, column + 1);
    }

    private int neighbor(final int row, final int column) {
        if (row < 0 || row >= size || column < 0 || column >= size) {
            return 0;
        }
        return Cells[row][column] ? 1 : 0;
    }
    
    private boolean[][] createCells() {
        return new boolean[size][size];
    }
}
