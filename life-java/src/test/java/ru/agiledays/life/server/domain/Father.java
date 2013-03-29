package ru.agiledays.life.server.domain;

import static ru.agiledays.life.server.domain.StringHelper.*;

public class Father {
    public Game game(String gameRepresentation) {
        return parseGame(gameRepresentation);
    }
}
