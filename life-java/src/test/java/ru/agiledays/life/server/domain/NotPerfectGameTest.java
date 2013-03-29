package ru.agiledays.life.server.domain;

import org.junit.*;
import static org.junit.Assert.*;

public class NotPerfectGameTest {
    // Govnotest: "Reveals implementation details, Breaks incapsulation of Game.cells"
    @Test
    public void testCreateGame() {
        Game game = new Game(2);

        boolean[][] expected = new boolean[][] {
            {false, false},
            {false, false},
        };
        assertArrayEquals(expected, game.Cells);
    }

    // Govnotest: "Hard to understand"
    @Test
    public void testCreateGameAnySize() {
        Game game = new Game(3);

        assertFalse(game.Cells[0][0]);
        assertFalse(game.Cells[0][1]);
        assertFalse(game.Cells[0][2]);
        assertFalse(game.Cells[1][0]);
        assertFalse(game.Cells[1][1]);
        assertFalse(game.Cells[1][2]);
        assertFalse(game.Cells[2][0]);
        assertFalse(game.Cells[2][1]);
        assertFalse(game.Cells[2][1]);
    }

    @Test
    public void testWithTwoNeighbors() {
        Game game = new Game(3);
        game.giveBirth(0, 0);
        game.giveBirth(0, 1);
        game.giveBirth(1, 1);

        game.step();

        assertTrue(game.Cells[1][1]);
    }

    @Test
    public void testWithThreeNeighbors() {
        Game game = new Game(3);
        game.giveBirth(0, 0);
        game.giveBirth(0, 2);
        game.giveBirth(2, 0);

        game.step();

        assertTrue(game.Cells[1][1]);
    }

    // Govnotest: "Reveals implementation details, Breaks incapsulation of Game.cells"
    @Test
    public void testAllCellsWithThreeNeighbors() {
        Game game = new Game(3);
        game.giveBirth(0, 0);
        game.giveBirth(2, 0);
        game.giveBirth(0, 2);

        game.step();

        boolean[][] expected = new boolean[][] {
            {false, false, false},
            {false, true, false},
            {false, false, false},
        };
        assertArrayEquals(expected, game.Cells);
    }
    
    
    private void assertArrayEquals(boolean[][] expected, boolean[][] actual) {
        assertEquals("Arrays have different sizes (the first one)", expected.length, actual.length);
        for (int row = 0; row < expected.length; row++) {
            assertEquals("Arrays have different sizes (the second one)", expected[row].length, actual[row].length);
            for (int column = 0; column < expected[row].length; column++) {
                assertEquals(String.format("Error in row %d column %d", row, column),
                        expected[row][column], actual[row][column]);
            }
        }
    }
}