package ru.agiledays.life.server.infrastructure;

import org.hibernate.Session;
import ru.agiledays.life.server.domain.GameRepository;
import ru.agiledays.life.server.infrastructure.dataobjects.*;

public class GameRepositoryHibernate implements GameRepository {
    private final Database database;

    public GameRepositoryHibernate(final Database database) {
        this.database = database;
    }

    public void save(final ru.agiledays.life.server.domain.Game game) {
        final Session session = database.openSession();

        Game doGame = (Game) session
                .createQuery("from Game where name = :gameName")
                .setParameter("gameName", game.name())
                .uniqueResult();
        if (doGame == null) {
            doGame = new Game();
        }
        
        new GameTranslator().persist(game, doGame);
        session.saveOrUpdate(doGame);
        
        session.flush();
    }
    
    public ru.agiledays.life.server.domain.Game load(final String name) {
        final Session session = database.openSession();

        Game doGame = (Game) session
                .createQuery("from Game where name = :gameName")
                .setParameter("gameName", name)
                .uniqueResult();
        if (doGame == null) {
            doGame = new Game();
        }
        
        return new GameTranslator().reconstitute(doGame);
    }
}
