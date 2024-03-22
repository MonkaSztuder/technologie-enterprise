package lab.requests.entities;

import jakarta.persistence.*;

import java.time.LocalDate;

@Entity
@Table(name = "request")
public class Request {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "id", nullable = false)
    private Long id;

    private LocalDate reqestDate;
    private String requestType;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public LocalDate getReqestDate() {
        return reqestDate;
    }

    public void setReqestDate(LocalDate reqestDate) {
        this.reqestDate = reqestDate;
    }

    public String getRequestType() {
        return requestType;
    }

    public void setRequestType(String requestType) {
        this.requestType = requestType;
    }
}