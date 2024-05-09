if (!requireNamespace("ggplot2", quietly = TRUE)) {
  install.packages("ggplot2")
}


library(ggplot2)

data <- readLines("C:\\Users\\RedMa\\OneDrive\\Рабочий стол\\Курсач\\ml-1m\\ratings.dat")
data <- gsub("::", " ", data)
data <- textConnection(data)
data <- read.table(data)




colnames(data) <- c("User_ID", "Movie_ID", "Rating", "Timestamp")




num_rows_to_remove <- nrow(data) - 100000


indices_to_remove <- seq(1, nrow(data), length.out = num_rows_to_remove)


data <- data[-indices_to_remove, ]

write.table(data, file = "C:\\Users\\RedMa\\OneDrive\\Рабочий стол\\Курсач\\ml-1m\\ratings2.dat", sep = "::", row.names = FALSE, col.names = FALSE)




ggplot(data, aes(x = Rating)) +
  geom_bar(fill = "skyblue", color = "black") +
  labs(title = "Распределение оценок",
       x = "Оценка",
       y = "Количество") +
  scale_y_continuous(labels = scales::comma) +  
  theme_minimal()


cat("Характеристики распределения оценок:\n")
cat("Медиана:", median(data$Rating), "\n")
cat("Среднее:", mean(data$Rating), "\n")
cat("Мода:", names(sort(-table(data$Rating))[1]), "\n")
cat("Стандартное отклонение:", sd(data$Rating), "\n")

cat("\nХарактеристики количества оценок, поставленных пользователями:\n")
cat("Среднее количество оценок на пользователя:", mean(table(data$User_ID)), "\n")
cat("Минимальное количество оценок на пользователя:", min(table(data$User_ID)), "\n")
cat("Максимальное количество оценок на пользователя:", max(table(data$User_ID)), "\n")

cat("\nХарактеристики количества оценок, поставленных фильмам:\n")
cat("Среднее количество оценок на фильм:", mean(table(data$Movie_ID)), "\n")
cat("Минимальное количество оценок на фильм:", min(table(data$Movie_ID)), "\n")
cat("Максимальное количество оценок на фильм:", max(table(data$Movie_ID)), "\n")


ratings <- readLines("C:\\Users\\RedMa\\OneDrive\\Рабочий стол\\Курсач\\ml-1m\\ratings.dat")
ratings <- gsub("::", " ", ratings)
ratings <- textConnection(ratings)
ratings <- read.table(ratings)
colnames(ratings) <- c("User_ID", "Movie_ID", "Rating", "Timestamp")

movies <- read.delim("C:\\Users\\RedMa\\OneDrive\\Рабочий стол\\Курсач\\ml-1m\\movies2.dat", header = FALSE, sep = "%")
colnames(movies) <- c("Movie_ID", "Title", "Genres")

merged_data <- merge(ratings, movies, by.x="Movie_ID")

genres_list <- strsplit(as.character(merged_data$Genres), "\\|")

genre_ratings <- data.frame(Genre=character(), Average_Rating=numeric(), Rating_Count=numeric(), stringsAsFactors=FALSE)

for (i in 1:length(genres_list)) {
  genres <- genres_list[[i]]
  for (genre in genres) {
    if (genre != "") {
      if (genre %in% genre_ratings$Genre) {
        idx <- which(genre_ratings$Genre == genre)
        genre_ratings$Average_Rating[idx] <- (genre_ratings$Average_Rating[idx] * genre_ratings$Rating_Count[idx] + merged_data$Rating[i]) / (genre_ratings$Rating_Count[idx] + 1)
        genre_ratings$Rating_Count[idx] <- genre_ratings$Rating_Count[idx] + 1
      } else {
        genre_ratings <- rbind(genre_ratings, list(Genre=genre, Average_Rating=merged_data$Rating[i], Rating_Count=1))
      }
    }
  }
}


print(genre_ratings)


ggplot(genre_ratings, aes(x = Genre, y = Average_Rating)) +
  geom_bar(stat = "identity", fill = "skyblue") +
  labs(title = "Средний рейтинг по жанрам", x = "Жанр", y = "Средний рейтинг")


ggplot(genre_ratings, aes(x = Genre, y = Rating_Count)) +
  geom_bar(stat = "identity", fill = "skyblue") +
  scale_y_continuous(labels = scales::comma) +
  labs(title = "Количество оценок по жанрам", x = "Жанр", y = "Количество оценок")



ratings <- readLines("C:\\Users\\RedMa\\OneDrive\\Рабочий стол\\Курсач\\ml-1m\\ratings.dat")
ratings <- gsub("::", " ", ratings)
ratings <- textConnection(ratings)
ratings <- read.table(ratings)
colnames(ratings) <- c("User_ID", "Movie_ID", "Rating", "Timestamp")
ratings <-  ratings[, c("User_ID", "Movie_ID", "Rating")]

movies <- read.delim("C:\\Users\\RedMa\\OneDrive\\Рабочий стол\\Курсач\\ml-1m\\movies2.dat", header = FALSE, sep = "%")
colnames(movies) <- c("Movie_ID", "Title", "Genres")

users <- read.delim("C:\\Users\\RedMa\\OneDrive\\Рабочий стол\\Курсач\\ml-1m\\users2.dat", header = FALSE, sep = "%")
colnames(users) <- c("User_ID", "Gender", "Age", "4", "5")
users <-  users[, c("User_ID", "Gender", "Age")]


merged_data <- merge(ratings, users, by.x="User_ID")

merged_data$Gender <- ifelse(merged_data$Gender == "M", 1, 2)

kmeans_model <- kmeans(merged_data, centers = 4)

print(kmeans_model)

library(factoextra)
fviz_cluster(kmeans_model, data = merged_data, geom = "point", stand = FALSE, ellipse.type = "norm")
