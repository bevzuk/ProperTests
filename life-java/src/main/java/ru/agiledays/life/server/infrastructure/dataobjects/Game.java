package ru.agiledays.life.server.infrastructure.dataobjects;

import java.util.HashSet;
import java.util.Set;

public class Game {
    private int size;
    private String name;
    private Set<Cell> cells;
    
    public int getSize() {
        return size;
    }
    
    public void setSize(final int size) {
        this.size = size;
    }
    
    public String getName() {
        return name;
    }
    
    public void setName(final String name) {
        this.name = name;
    }
    
    public Set<Cell> getCells() {
        return cells;
    }

    public void setCells(final Set<Cell> cells) {
        this.cells = cells;
    }
    
    public Game() {
        cells = new HashSet<Cell>();
    }
}
