package ru.agiledays.life.server.infrastructure;

import ru.agiledays.life.server.infrastructure.dataobjects.*;

public class GameTranslator {
    public void persist(final ru.agiledays.life.server.domain.Game game,
                        final Game doGame) {
        doGame.setSize(game.size());
        doGame.setName(game.name());
        persistCells(game, doGame);
    }

    private void persistCells(final ru.agiledays.life.server.domain.Game game,
                              final Game doGame) {
        doGame.getCells().clear();
        for (int row = 0; row < game.size(); row++) {
            for (int column = 0; column < game.size(); column++) {
                if (game.getCell(row, column).isAlive()) {
                    doGame.getCells().add(new Cell(row, column));
                }
            }
        }
    }

    public ru.agiledays.life.server.domain.Game reconstitute(Game doGame) {
        final ru.agiledays.life.server.domain.Game game =
                new ru.agiledays.life.server.domain.Game(doGame.getSize(), doGame.getName());
        for (Cell cell: doGame.getCells()) {
            game.giveBirth(cell.getY(), cell.getX());
        }
        return game;
    }
}
