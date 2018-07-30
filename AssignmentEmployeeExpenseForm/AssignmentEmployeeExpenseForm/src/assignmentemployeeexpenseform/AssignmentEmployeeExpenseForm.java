/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package assignmentemployeeexpenseform;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Collection;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Scanner;
import javafx.application.Application;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.chart.PieChart;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.DatePicker;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.ColumnConstraints;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.Pane;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.scene.text.Font;
import javafx.scene.text.FontPosture;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import javax.swing.event.ChangeListener;

/**
 *
 * @author Bhuller
 */
public class AssignmentEmployeeExpenseForm extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        StackPane root=new StackPane();
        HBox hbox= new HBox();
        VBox vbox=new VBox(7);
        GridPane grid=new GridPane();
        GridPane grid1=new GridPane();
        Button submit= new Button("Submit");
        Button exit=new Button("Exit");
        
        ObservableList<PieChart.Data> pieChartData =
                FXCollections.observableArrayList(
                new PieChart.Data("Food", 40),
                new PieChart.Data("Transportation", 25),
                new PieChart.Data("Lodging", 20),
                new PieChart.Data("Others", 15));
        final PieChart pie=new PieChart(pieChartData);
        pie.setTitle("Expense Form");
        
        vbox.getChildren().add(hbox);
        Label employee= new Label("Employee:");
        Label id= new Label("ID:");
        Label date= new Label("Date:");
        Label destination= new Label("Destination:");
        TextField[] text=new TextField[3];
        text[0]=new TextField();
        text[1]=new TextField();
        text[2]=new TextField();
        DatePicker datePicker = new DatePicker();
              
        
        
        grid.setVgap(5);
        
        hbox.setPadding(new Insets(15,0,0,10));
        hbox.getChildren().add(grid);
        hbox.getChildren().add(pie);
        grid.add(employee, 0, 0);
        grid.add(id, 0, 1);
        grid.add(date, 0, 2);
        grid.add(destination,0,3);
        
        grid.getColumnConstraints().add(new ColumnConstraints(100));
        grid.getColumnConstraints().add(new ColumnConstraints(100));
        
        hbox.setMargin(pie, new Insets(0, 0, 0, 100));
        
        grid.add(text[0], 1, 0);
        grid.add(text[1], 1, 1);
        grid.add(datePicker, 1, 2);
        grid.add(text[2], 1, 3);
        
        Text category=new Text("Category");
        category.setFont(Font.font(STYLESHEET_CASPIAN, FontPosture.REGULAR, 12));
        Text desc=new Text("Description");
        desc.setFont(Font.font(STYLESHEET_CASPIAN, FontPosture.REGULAR, 12));
        Text amt=new Text("Amount");
        amt.setFont(Font.font(STYLESHEET_CASPIAN, FontPosture.REGULAR, 12));
        ComboBox[] listBox= new ComboBox[4];
         listBox[0]=new ComboBox();
         listBox[1]=new ComboBox();
         listBox[2]=new ComboBox();
         listBox[3]=new ComboBox();
         
         listBox[0].getItems().addAll("Food","Transportation","Lodging","Other");
         listBox[1].getItems().addAll("Food","Transportation","Lodging","Other");
         listBox[2].getItems().addAll("Food","Transportation","Lodging","Other");
         listBox[3].getItems().addAll("Food","Transportation","Lodging","Other");
        
        vbox.getChildren().add(grid1);
        
        TextField[] txtDesc=new TextField[4];
        TextField[] txtAmt=new TextField[4];
        txtDesc[0]=new TextField();
        txtDesc[1]=new TextField();
        txtDesc[2]=new TextField();
        txtDesc[3]=new TextField();
        
        txtAmt[0]=new TextField();
        txtAmt[1]=new TextField();
        txtAmt[2]=new TextField();
        txtAmt[3]=new TextField();
        
        
        
//        txtAmt[0].textProperty().addListener(new ChangeListener<String>() {
//            public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue) {
//                if (!newValue.matches("\\d{0,7}([\\.]\\d{0,4})?")) {
//                    txtAmt[0].setText(oldValue);
//                }
//            }
//        });
        
        grid1.getColumnConstraints().add(new ColumnConstraints(100));
        grid1.getColumnConstraints().add(new ColumnConstraints(250));    
        grid1.getColumnConstraints().add(new ColumnConstraints(70));
        
        grid1.setVgap(5);
        grid1.setHgap(25);
        grid1.setPadding(new Insets(5,5,5,15));
        grid1.add(category, 0, 0);
        grid1.add(desc,1,0);
        grid1.add(amt, 2, 0);
        grid1.add(listBox[0], 0, 1);
        grid1.add(listBox[1], 0, 2);
        grid1.add(listBox[2], 0, 3);
        grid1.add(listBox[3], 0, 4);
        
        grid1.add(txtDesc[0], 1, 1);
        grid1.add(txtDesc[1],1,2);
        grid1.add(txtDesc[2], 1, 3);
        grid1.add(txtDesc[3], 1, 4);
        grid1.add(txtAmt[0], 2, 1);
        grid1.add(txtAmt[1],2,2);
        grid1.add(txtAmt[2], 2, 3);
        grid1.add(txtAmt[3], 2, 4);
        
        Label total=new Label("Total:");
        TextField txtResult=new TextField();
        txtResult.setEditable(false);
        
        grid1.add(submit, 0, 7);
        grid1.add(total, 1, 7);
        grid1.add(txtResult, 2, 7);
        grid1.setMargin(total, new Insets(0, 0, 0, 200));
        
//        txtAmt[0].textProperty().addListener(new ChangeListener<String>() {
//        
//            public void changed(ObservableValue<? extends String> observable,
//            String oldValue, String newValue) {
//                double amt1=Double.parseDouble(newValue);
//                
//                txtResult.appendText( newValue );
//    }
//});
                
        try (BufferedReader check=new BufferedReader(new FileReader(new File("employee_info.txt")))){
        
        String line;
        if ((line=check.readLine())==null){
            text[0].setText("");
            text[1].setText("");
        }
        else{
        List l=readFileInList("employee_info.txt");
        Iterator<String> itr= l.iterator();        
            text[0].setText(itr.next());
                
                text[1].setText(itr.next());
                
        }
                
        }catch(IOException e){
            e.printStackTrace();
        }                 
            
        
         
        submit.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) { 
                    try (PrintWriter out = new PrintWriter(new BufferedWriter(
                        new FileWriter("employee_info.txt", false)))) { 
                        out.println(text[0].getText());
                        out.println(text[1].getText());
                    } catch (IOException ioe) {
                        ioe.printStackTrace();
                    }
                    try (PrintWriter out = new PrintWriter(new BufferedWriter(
                        new FileWriter("expenses.txt", true)))) { 
                        out.println("Name: "+text[0].getText()+", ID: "+text[1].getText()+
                                ", Date: "+datePicker.getValue().toString()+", Destination: "+text[2].getText());
                        for(int i=0; i<listBox.length; i++){
                        out.println("Category: "+listBox[i].getValue().toString()+", Description: "+txtDesc[i].getText()+
                                ", Amount: "+txtAmt[i].getText());
                        }
//                        out.println("Category: "+listBox[1].getTypeSelector()+", Description: "+txtDesc[1].getText()+
//                                ", Amount: "+txtAmt[1].getText());
//                        out.println("Category: "+listBox[2].getTypeSelector()+", Description: "+txtDesc[2].getText()+
//                                ", Amount: "+txtAmt[2].getText());
//                        out.println("Category: "+listBox[3].getTypeSelector()+", Description: "+txtDesc[3].getText()+
//                                ", Amount: "+txtAmt[3].getText());
                    } catch (IOException ioe) {
                        ioe.printStackTrace();
                    }
                    primaryStage.close();
            }
        });
    

         grid1.setOnKeyTyped(new EventHandler<KeyEvent>(){
            @Override
            public void handle(KeyEvent key){
            double amt1= Double.parseDouble(txtAmt[0].getText());
            double amt2= Double.parseDouble(txtAmt[1].getText());
            double amt3= Double.parseDouble(txtAmt[2].getText());
            double amt4= Double.parseDouble(txtAmt[3].getText());
            double rslt=amt1+amt2+amt3+amt4;
            String result= Double.toString(rslt);
            txtResult.setText(result);
            }
         });
         
        
        //root.getChildren().add(btn);
        root.getChildren().add(vbox);
       
        
        Scene scene = new Scene(root, 500, 550);
        
        primaryStage.setTitle("Expense Form");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    public static List<String> readFileInList(String fileName){
        List<String> lines = Collections.emptyList();
        try{
            lines=Files.readAllLines(Paths.get(fileName), StandardCharsets.UTF_8);
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
        return lines;
    }
}
