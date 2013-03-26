package ru.agiledays.life.server.infrastructure;

import org.hibernate.*;

public interface Database {
    Session openSession();
    void close(final Session session);
}
