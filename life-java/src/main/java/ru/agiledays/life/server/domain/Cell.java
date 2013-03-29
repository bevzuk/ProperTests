package ru.agiledays.life.server.domain;

public class Cell {
        private final boolean isAlive;
        
        public Cell(final boolean isAlive) {
            this.isAlive = isAlive;
        }
        
        public boolean isDead() {
            return !isAlive;
        }
        
        public boolean isAlive() {
            return isAlive;
        }
}
