package ru.agiledays.life.server.domain;

public interface GameRepository {
    void save(final Game game);
    Game load(final String name);
}
