package ru.agiledays.life.server.application;

import ru.agiledays.life.server.domain.Game;
import ru.agiledays.life.server.infrastructure.Database;
import ru.agiledays.life.server.infrastructure.GameRepositoryHibernate;

public class MainGameService implements GameService {
    public void save(final Game game, final Database database) {
        new GameRepositoryHibernate(database).save(game);
    }

    public Game load(final String name, final Database database) {
        return new GameRepositoryHibernate(database).load(name);
    }
}
