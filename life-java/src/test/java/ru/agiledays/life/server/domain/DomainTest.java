package ru.agiledays.life.server.domain;

import org.junit.Assert;
import static ru.agiledays.life.server.domain.StringHelper.*;

public class DomainTest {
    public DomainTest() {
        create = new Father();
    }
    
    protected static class AssertThat {
        public static void areEqual(final String expectedGameRepresentation, final Game game) {
            int row = 0;
            final String[] lines = splitLines(expectedGameRepresentation);
            final char[][] errors = asCharMap(lines);
            boolean hasErrors = false;

            for (String line: lines) {
                int column = 0;
                for (char code: line.toCharArray()) {
                    switch (code) {
                        case '.':
                            if (game.getCell(row, column).isAlive()) {
                                hasErrors = true;
                                errors[row][column] = '*';
                            }
                            break;
                        case 'x':
                        case 'X':
                            if (game.getCell(row, column).isDead()) {
                                hasErrors = true;
                                errors[row][column] = '*';
                            }
                            break;
                    }
                    column++;
                }
                row++;
            }
            if (hasErrors) {
                Assert.fail("Games doesn't match:" + newLine + convertToString(errors));
            }
        }
        
        private static String convertToString(final char[][] errors) {
            final StringBuffer sb = new StringBuffer();
            for (char[] error: errors) {
                sb.append(new String(error));
                sb.append(newLine);
            }
            return sb.toString();
        }
    }
    
    protected final Father create;
}
