import { Component, OnInit } from '@angular/core';
import { RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { GoogleDriveService } from '../../../services/app.googledrive.service';
import { LocalStorageService } from 'angular-2-local-storage';

@Component({
    selector: 'upload-document',
    templateUrl: './app.clientdetails.uploaddocument.html',
    providers: [GoogleDriveService]
})
export class UploadDocumnetComponent implements OnInit {
    public FileDownLoadPath: string = "";
    public FileList: any = {}
    public file;
    public GetAllDriveFile: any = []
    public GetDriveFinalData: {
        'SerialNumber': '',
        'Name': '',
        'Location': ''
    };

    public index = 1

    constructor(private GoogleDrive: GoogleDriveService, private _LocalStorageService: LocalStorageService) { }

    ngOnInit() {

        if (this._LocalStorageService.get("ApplicantID") != undefined && this._LocalStorageService.get("ApplicantID") != null)
            console.log(this._LocalStorageService.get("ApplicantID"))
        this.GoogleDrive.GetDriveFiles(<string>this._LocalStorageService.get("ApplicantID")).subscribe(res => this.GetDriveFilesSuccess(res), res => this.GetDriveFilesError(res));
    }

    GetDriveFilesSuccess(res) {
        if (JSON.parse(res._body) != null || JSON.parse(res._body) != undefined) {
            this.GetAllDriveFile = JSON.parse(res._body);
            this.index = 1
            this.GetDriveFinalData = this.GetAllDriveFile.map(object => {
                return { Location: 'Google Drive', SerialNumber: this.index++, Name: object.Name, Id: object.Id };

            });
        }
    }

    GetDriveFilesError(res) { }

    FileUpload(event) {
        this.FileList = event.target.files;
        if (this.FileList.length > 0) {
            this.file = event.target.files[0]
            let formData: FormData = new FormData();
            formData.append('file', this.file, this.file.name);
            this.GoogleDrive.FileUpload(formData).subscribe(res => this.FileUploadSuccess(res), res => this.FileUploadError(res));
        }
    }

    FileUploadSuccess(res) {
        this.GoogleDrive.GetDriveFiles(this._LocalStorageService.get("ApplicantID")).subscribe(res => this.GetDriveFilesSuccess(res), res => this.GetDriveFilesError(res));
    }

    FileUploadError(res) { }

    DeleteFile(file) {
        this.GoogleDrive.DeleteFiles(file).subscribe(res => this.DeleteFilesSuccess(res), res => this.DeleteFilesError(res));
    }

    DeleteFilesSuccess(res) {
        this.GoogleDrive.GetDriveFiles(this._LocalStorageService.get("ApplicantID")).subscribe(res => this.GetDriveFilesSuccess(res), res => this.GetDriveFilesError(res));
    }

    DeleteFilesError(res) { }

    DownloadFile(Id) {
        this.GoogleDrive.DownloadFile(Id).subscribe(res => this.DownloadFileSuccess(res), res => this.DownloadFileError(res));
    }

    DownloadFileSuccess(res) {
        debugger;
        if (res._body.trim().length > 0) {
            this.FileDownLoadPath = res._body.trim().replace('"', '').replace('"', '');

            setTimeout(() => {
                this.FileDownLoadPath = "";
            }, 10000);
        }
    };

    DownloadFileError(res) { }

}
