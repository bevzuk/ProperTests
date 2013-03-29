package ru.agiledays.life.server.application;

import ru.agiledays.life.server.domain.Game;
import ru.agiledays.life.server.infrastructure.Database;

public interface GameService {
    void save(final Game game, final Database database);
    Game load(final String name, final Database database);
}
