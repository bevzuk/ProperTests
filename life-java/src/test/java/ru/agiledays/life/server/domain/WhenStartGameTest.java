package ru.agiledays.life.server.domain;

import org.junit.*;

public class WhenStartGameTest extends DomainTest {
    @Test
    public void canCreateGameOfSize2() {
        final Game game = new Game(2);
        AssertThat.areEqual("..\n" +
                            "..", game);
    }

    @Test
    public void canCreateGameOfSize3() {
        final Game game = new Game(3);
        AssertThat.areEqual("...\n" +
                            "...\n" +
                            "...", game);
    }

    @Test
    public void canSetAliveCells() {
        final Game game = new Game(2);
        game.giveBirth(0, 0);
        game.giveBirth(0, 1);
        AssertThat.areEqual("xx\n" +
                            "..", game);
    }
}
