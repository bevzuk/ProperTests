package ru.agiledays.life.server.domain;

import org.junit.*;
import static org.junit.Assert.*;

public class WhenMakeStepTest extends DomainTest {
    @Test
    public void anyLiveCellWithZeroNeighborsDies() {
        final Game game = new Game(3);
        game.giveBirth(1, 1);

        game.step();

        AssertThat.areEqual("...\n" +
                            "...\n" +
                            "...", game);
    } 

    @Test
    public void anyLiveCellWithOneNeighborsDies() {
        final Game game = new Game(3);
        game.giveBirth(0, 0);
        game.giveBirth(1, 1);

        game.step();

        AssertThat.areEqual("...\n" +
                            "...\n" +
                            "...", game);
    } 

    @Test
    public void anyLiveCellWithThreeNeighborsLives() {
        final Game game = new Game(3);
        game.giveBirth(0, 0);
        game.giveBirth(0, 2);
        game.giveBirth(2, 0);
        game.giveBirth(1, 1);

        game.step();

        assertTrue(game.getCell(1, 1).isAlive());
    } 

    @Test
    public void anyLiveCellWithFourNeighborsDiesByOvercrowding() {
        final Game game = create.game("x.x\n" +
                                      ".x.\n" +
                                      "x.x");

        game.step();

        assertTrue(game.getCell(1, 1).isDead());
    }

    @Test
    public void anyLiveCellWithThreeNeighborsLives2() {
        final Game game = create.game("x.x\n" +
                                      "...\n" +
                                      "x..");

        game.step();

        AssertThat.areEqual("...\n" +
                            ".x.\n" +
                            "...", game);
    }
}
