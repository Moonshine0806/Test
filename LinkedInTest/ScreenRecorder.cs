using ScreenRecorderLib;

namespace LinkedInTest
{
    public class ScreenRecorder
    {
        private readonly Recorder _recorder;
        private bool _isRecording;
        private readonly string _videoPath;
        private ScreenRecordStatus _status;
        private string _error = string.Empty;

        private ScreenRecorder(string videoPath)
        {
            _recorder = Recorder.CreateRecorder();
            _recorder.OnRecordingComplete += Recorder_OnRecordingComplete;
            _recorder.OnRecordingFailed += Recorder_OnRecordingFailed;
            _recorder.OnStatusChanged += Recorder_OnStatusChanged;
            this._videoPath = videoPath;
        }

        public static ScreenRecorder CreateRecorder(string videoPath)
        {
            var screenRecorder = new ScreenRecorder(videoPath);
            return screenRecorder;
        }

        public ScreenRecordStatus Status
        {
            get
            {
                return this._status;
            }
        }

        public string Error => this._error;

        public void StartRecording()
        {
            _recorder.Record(this._videoPath);
        }

        public void EndRecording()
        {
            _recorder.Stop();
        }

        private void Recorder_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            _isRecording = false;
        }

        private void Recorder_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            this._error = e.Error;
            this._status = ScreenRecordStatus.Fail;
            _isRecording = false;
        }

        private void Recorder_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            switch (e.Status)
            {
                case RecorderStatus.Idle:
                    this._status = ScreenRecordStatus.Idle;
                    break;
                case RecorderStatus.Recording:
                    _isRecording = true;
                    this._status = ScreenRecordStatus.Recording;
                    break;
                case RecorderStatus.Paused:
                    this._status = ScreenRecordStatus.Paused;
                    break;
                case RecorderStatus.Finishing:
                    this._status = ScreenRecordStatus.Finishing;
                    break;
                default:
                    break;
            }
        }
    }

    public enum ScreenRecordStatus : int
    {
        Idle = 0,
        Recording = 1,
        Paused = 2,
        Finishing = 3,
        Fail = -1,
    }
}
