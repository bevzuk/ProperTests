package ru.agiledays.life.server.domain;

public class StringHelper {
    public static final String newLine = System.getProperty("line.separator");
    
    public static Game parseGame(final String gameRepresentation) {
        final char[][] charMap = asCharMap(splitLines(gameRepresentation));
        final Game game = new Game(charMap.length);
        for (int row = 0; row < charMap.length; row++) {
            final char[] line = charMap[row];
            for (int column = 0; column < line.length; column++) {
                final char c = line[column];
                if (c == 'x' || c == 'X') {
                    game.giveBirth(row, column);
                }
            }
        }
        return game;
    }
    
    public static String[] splitLines(final String multiLineText) {
        final String[] lines = multiLineText.split("[\\r?\\n]+");
        for (int i = 0; i < lines.length; i++) {
            lines[i] = lines[i].trim();
        }
        return lines;
    }
    
    public static char[][] asCharMap(final String[] lines) {
        final char[][] charMap = new char[lines.length][];
        for (int i = 0; i < lines.length; i++) {
            charMap[i] = lines[i].toCharArray();
        }
        return charMap;
    }
}
