package ru.agiledays.life.server.infrastructure;

import org.hibernate.*;

public class RealDatabase implements Database {
    public Session openSession() {
        return null;
    }

    public void close(final Session session) {
        session.close();
    }
}
