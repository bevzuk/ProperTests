package ru.agiledays.life.server.domain;

import org.junit.*;

public class WhenEvoluteTest extends DomainTest {
    @Test
    public void anyLiveCellWithZeroNeighborsDies() {
        final Game game = create.game("...\n" +
                                      ".x.\n" +
                                      "...");

        game.step();

        AssertThat.areEqual("...\n" +
                            "...\n" +
                            "...", game);
    }

    @Test
    public void anyDeadCellWithThreeNeighborsArises() {
        final Game game = create.game("x.x\n" +
                                      "...\n" +
                                      "x..");

        game.step();

        AssertThat.areEqual("...\n" +
                            ".x.\n" +                
                            "...", game);
    }
}
