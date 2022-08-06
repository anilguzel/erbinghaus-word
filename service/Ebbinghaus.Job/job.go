package main

import (
	"fmt"
	"go.mongodb.org/mongo-driver/bson"
    "github.com/jasonlvhit/gocron" 
	"context"
        "go.mongodb.org/mongo-driver/mongo"
        "go.mongodb.org/mongo-driver/mongo/options"
		"Ebbinghaus.Job/models"

)

func task() {
	cards,err := getCards()
	if err != nil {
		panic(err)
	}
	
	fmt.Println(cards[0].Id)
}

func getCards() ([]*models.Card, error) {
	// A slice of tasks for storing the decoded documents
	var result []*models.Card

	client := getMongo()
	cards := client.Database("ebbinghaus").Collection("Card")
	filter := bson.D{{"Words", 
				bson.D{{"$elemMatch", 
					bson.D{{"is_done", false}}}}}}
	cur, err := cards.Find(context.TODO(), filter)
	if err != nil {
		panic(err)
	}

	for cur.Next(context.TODO()){
		var t models.Card
		err := cur.Decode(&t)
		if err != nil {
			return result, err
		}

		result = append(result, &t)
	}

	if err := cur.Err(); err != nil {
		return result, err
	}

	cur.Close(context.TODO())

	if len(result) == 0 {
		return result, mongo.ErrNoDocuments
	}

	return result, nil
}

func getMongo() (*mongo.Client) {
	client, err := mongo.Connect(context.TODO(), options.Client().ApplyURI("mongodb://localhost:27017"))
	if err != nil {
			panic(err)
	}

	return client
}

func main() {
    s := gocron.NewScheduler()
    s.Every(1).Minute().Do(task)
    <- s.Start()
}